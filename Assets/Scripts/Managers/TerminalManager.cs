using System;
using System.Collections;
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
        [Title("Phase Data")] [SerializeField] private PhaseData[] phaseDatas;

        [SerializeField] private TextMeshProUGUI dialogueText;


        [SerializeField] private GameEventSO OnDialogStarted;
        [SerializeField] private GameEventSO OnDialogEnded;


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
                    
                    foreach (char letter in GetCurrentPhase().dialogues[_dialogueCount])
                    {
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
                        _dialogueCount = 0;
                        var ifm = GetComponent<InputFieldManager>();
                        yield return new WaitForSeconds(waitOffset);
                        OnDialogEnded.Invoke();
                        
                        if (!Timer.Timer.Instance.isActive) Timer.Timer.Instance.StartTimer(GetCurrentPhase().phaseTimer);
                        yield break;
                    }
                }
            }
        }


        private int GetLastDialogText()
        {
            return GetCurrentPhase().dialogues.Length - 1;
        }

        private PhaseData GetCurrentPhase()
        {
            return phaseDatas[GameManager.Instance.CurrentPhaseIndex];
        }
    }
}