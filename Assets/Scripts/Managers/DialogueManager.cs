using System;
using System.Collections;
using Sirenix.OdinInspector;
using SO;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class DialogueManager : MonoBehaviour
    {
        [Title("Phase Data")]
        [SerializeField] private PhaseData[] phaseDatas;

        [Title("Action Data")]
        [SerializeField] private GameEventSO PasswordSucess;
        [SerializeField] private GameEventSO PasswordFailed;
        
        [SerializeField] private TextMeshProUGUI dialogueText;

        private int _dialogueCount;
        
        
        private void OnEnable()
        {
            SetDialogueEffect();
        }

        private void SetDialogueEffect()
        {
            
            StartCoroutine(CO_SetDialogueEffect());


            IEnumerator CO_SetDialogueEffect()
            {
                dialogueText.text = "";

                foreach (var letter in GetCurrentPhase().dialogues[_dialogueCount])
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.05f);
                } 
                
                yield return new WaitForSeconds(1f);
                
                if (_dialogueCount < GetCurrentPhase().dialogues.Length - 1)
                {
                    _dialogueCount++;
                    StartCoroutine(CO_SetDialogueEffect());
                }
                else
                {
                    yield break;
                }
                
                yield return new WaitForSeconds(2f);
                
                
                //TODO: Set OnDialogueEndEvent..
                _dialogueCount = 0; // reset the dialogue count for next phases...
            }
        }

        private PhaseData GetCurrentPhase() => phaseDatas[GameManager.Instance.CurrentPhaseIndex];
    }
}
