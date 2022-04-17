using System;
using System.Collections;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using SO;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class TerminalManager : MonoBehaviour
    {
        [Range(0.5f, 1.5f)] public float waitOffset;

        [Range(0.01f, 0.1f)] public float letterInterval = 0.05f;

        [SerializeField] private TextMeshProUGUI dialogueText;
        
        
        [SerializeField] private GameEventSO OnDialogStarted;
        [SerializeField] private GameEventSO OnDialogEnded;

        [SerializeField] private GameEventSO GameWin;
        
        [SerializeField] private PhaseData lastLevel;


        private int _dialogueCount;


        private void Start()
        {
            SetCurrentDialogue();
        }

        private void OnEnable()
        {
            if (GetComponent<InputFieldManager>().hasDialogue) SetCurrentDialogue();
        }


        public void SetCurrentDialogue()
        {
            dialogueText.text = "";

            StartCoroutine(CO_SetDialogueEffect());


            IEnumerator CO_SetDialogueEffect()
            {
                OnDialogStarted.Invoke();
                yield return new WaitForSeconds(0.5f);

                while (true)
                {
                    Timer.Timer.Instance.StopTimer = false;

                    foreach (char letter in GameManager.Instance.GetCurrentPhase().dialogues[_dialogueCount])
                    {
                        AudioManager.Instance.PlayKeyboardClickSound();
                        dialogueText.text += letter;
                        yield return new WaitForSeconds(letterInterval);

                        if (char.IsPunctuation(letter) && !letter.Equals(',')) yield return new WaitForSeconds(0.3f);
                    }

                    if (_dialogueCount < GetLastDialogText())
                    {
                        yield return new WaitForSeconds(waitOffset); // Wait enough time for texts...
                        _dialogueCount++;
                    }
                    else
                    {
                        if (GameManager.Instance.GetCurrentPhase() == lastLevel)
                        {
                            _dialogueCount = 0;
                            GameManager.Instance.IsGameOver = true;
                            Debug.Log("This one was the last level...");
                            gameObject.SetActive(false);
                            GameWin.Invoke();
                            yield break;
                        }

                        _dialogueCount = 0;
                        var ifm = GetComponent<InputFieldManager>();
                        yield return new WaitForSeconds(1.5f);
                        OnDialogEnded.Invoke();
                        if (!Timer.Timer.Instance.isActive)
                            Timer.Timer.Instance.StartTimer(GameManager.Instance.GetCurrentPhase().phaseTimer);
                        yield break;
                    }
                }
            }
        }


        private int GetLastDialogText() => GameManager.Instance.GetCurrentPhase().dialogues.Length - 1;
    }
}