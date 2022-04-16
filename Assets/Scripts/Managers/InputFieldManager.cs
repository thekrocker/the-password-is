using System.Collections;
using Sirenix.OdinInspector;
using SO;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class InputFieldManager : MonoBehaviour
    {
        private TMP_InputField _inputField;
        [SerializeField] private GameObject passwordInputArea;
        
        [SerializeField] private TextMeshProUGUI terminalText;
        [Range(0.05f,0.5f)]
        [SerializeField] private float terminalTextInterval;
        
        [Title("Actions")] 
        [SerializeField] private GameEventSO OnDialogStarted;
        [SerializeField] private GameEventSO OnDialogEnded;

        [SerializeField] private GameEventSO PasswordSuccess;
        [SerializeField] private GameEventSO PasswordFailed;

        
        private char[] _letters = "#$%&()*/0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSŞTUVWXYZ^_`abcdefghijklmnopqrstuvwxyz{}".ToCharArray();

        private void GetReferences()
        {
            _inputField = GetComponent<TMP_InputField>();
            

        }

        private int _letterLength = 440;

        void OnEnable()
        {
            GetReferences();
            
            SubscribeEvents();
            
            ActivateInputField(); // @@todo: check later if needed

            
        }

        private void SetRandomTerminalText()
        {
            StartCoroutine(CO_SetRandomText());
            
            IEnumerator CO_SetRandomText()
            {
                while (!GameManager.Instance.HasDialogue)
                {
                    terminalText.text = "";
                    
                    for (var i = 0; i < _letterLength; i++) terminalText.text += _letters[Random.Range(0, _letters.Length)];
                    yield return new WaitForSeconds(terminalTextInterval);
                    
                    if (GameManager.Instance.HasDialogue) yield break; //@toDO: Extra check here to cut the random terminal text...
                }
   
            }
        }
        


        void SubscribeEvents()
        {
            OnDialogStarted.GameEvent += DisablePasswordInput;
            
            OnDialogEnded.GameEvent += SetRandomTerminalText;
            OnDialogEnded.GameEvent += ActivatePasswordInput;
            
            // Password Success
            PasswordSuccess.GameEvent += ClearInputField;


            //Password Failed
            PasswordFailed.GameEvent += ClearInputField;
            PasswordFailed.GameEvent += ActivateInputField;
        }

        private void ActivatePasswordInput() => passwordInputArea.SetActive(true);
        private void DisablePasswordInput() => passwordInputArea.SetActive(false);

        private void OnDisable()
        {
            if (GameManager.Instance == null) return;
            
            GameManager.Instance.HasDialogue = false;
            
            
            OnDialogStarted.GameEvent -= DisablePasswordInput;
            
            OnDialogEnded.GameEvent -= SetRandomTerminalText;
            OnDialogEnded.GameEvent -= ActivatePasswordInput;

            // Password Success
            PasswordSuccess.GameEvent -= ClearInputField;

            //Password Failed
            PasswordFailed.GameEvent -= ClearInputField;
            PasswordFailed.GameEvent -= ActivateInputField;
        }


        private void ClearInputField()
        {
            _inputField.text = "";
        }

        private void ActivateInputField()
        {
            _inputField.ActivateInputField();
        }
    }
}