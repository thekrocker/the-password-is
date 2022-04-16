using System;
using System.Collections;
using Sirenix.OdinInspector;
using SO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Managers
{
    public class InputFieldManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private GameObject passwordInputArea;

        [SerializeField] private TextMeshProUGUI terminalText;
        [Range(0.05f, 0.5f)] [SerializeField] private float terminalTextInterval;
        
        

        private readonly char[] _letters = "#$%&()*/0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSŞTUVWXYZ^_`abcdefghijklmnopqrstuvwxyz{}"
            .ToCharArray();


        private int _letterLength = 440;


        private void Start() => passwordInputArea.SetActive(false);

        void OnEnable()
        {
            ActivateInputField(); // @@todo: check later if needed
            if (!hasDialogue) SetRandomTerminalText();
        }


        public bool hasDialogue;
        
        public void SetRandomTerminalText()
        {
            StartCoroutine(CO_SetRandomText());
            
            IEnumerator CO_SetRandomText()
            {
                while (!hasDialogue)
                {
                    terminalText.text = "";

                    for (var i = 0; i < _letterLength; i++)
                        terminalText.text += _letters[Random.Range(0, _letters.Length)];
                    yield return new WaitForSeconds(terminalTextInterval);

                    if (hasDialogue)
                    {
                        yield break;
                    } 
                }
            }
        }
        

        public void ActivatePasswordInput()
        {
            hasDialogue = false;
            ActivateInputField();
            passwordInputArea.SetActive(true);
        }

        public void DisablePasswordInput()
        {
            hasDialogue = true;
            passwordInputArea.SetActive(false);
        }
        
        public void ClearInputField()
        {
            _inputField.text = "";
        }

        public void ActivateInputField()
        {
            _inputField.ActivateInputField();
        }
    }
}