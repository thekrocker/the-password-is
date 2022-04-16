using System;
using System.Collections;
using Sirenix.OdinInspector;
using SO;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class TerminalDialogueManager : MonoBehaviour
    {
        [Range(0.5f, 1.5f)] public float waitOffset;

        [Title("Phase Data")] [SerializeField] private PhaseData[] phaseDatas;

        [SerializeField] private TextMeshProUGUI dialogueText;

        [SerializeField] private GameEventSO OnPasswordSuccess;
        

        [SerializeField] private GameEventSO OnDialogEnded;
        [SerializeField] private GameEventSO OnDialogStarted;

        private int _dialogueCount;


        private void OnEnable()
        {
            SetCurrentDialogue();

            OnPasswordSuccess.GameEvent += SetCurrentDialogue;
        }

        private void OnDisable()
        {
            OnPasswordSuccess.GameEvent -= SetCurrentDialogue;
        }


        private void SetCurrentDialogue()
        {
            StartCoroutine(CO_SetDialogueEffect());

            OnDialogStarted.RaiseEvent();
            dialogueText.text = "";


            IEnumerator CO_SetDialogueEffect()
            {
                yield return new WaitForSeconds(0.2f);
                GameManager.Instance.HasDialogue = true;

                while (true)
                {
                    foreach (char letter in GetCurrentPhase().dialogues[_dialogueCount])
                    {
                        dialogueText.text += letter;
                        yield return new WaitForSeconds(0.05f);

                        if (char.IsPunctuation(letter) && !letter.Equals(',')) yield return new WaitForSeconds(0.3f);
                    }

                    if (_dialogueCount < GetLastDialogText())
                    {
                        Debug.Log(GetCurrentPhase().dialogues[_dialogueCount].Length * waitOffset);
                        yield return new WaitForSeconds(waitOffset); // Wait enough time for texts...
                        _dialogueCount++;
                    }
                    else
                    {
                        _dialogueCount = 0;
                        yield return new WaitForSeconds(waitOffset);
                        Debug.Log("Dialog ended...");
                        // Activate password entrance...
                        OnDialogEnded.RaiseEvent();
                        GameManager.Instance.HasDialogue = false;

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