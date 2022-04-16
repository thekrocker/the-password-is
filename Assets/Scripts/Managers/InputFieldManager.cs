using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class InputFieldManager : MonoBehaviour
{
    private TMP_InputField _inputField;
    
    [Title("Actions")] 
    [SerializeField] private GameEventSO PasswordSuccess;
    [SerializeField] private GameEventSO PasswordFailed;

    private void GetReferences()
    {
        _inputField = GetComponent<TMP_InputField>();
    }

    void OnEnable()
    {
        GetReferences();

        ActivateInputField(); // @@todo: check later if needed

        SubscribeEvents();
    }


    void SubscribeEvents()
    {
        // Password Success
        PasswordSuccess.GameEvent += ClearInputField;


        //Password Failed
        PasswordFailed.GameEvent += ClearInputField;
        PasswordFailed.GameEvent += ActivateInputField;
    }

    private void OnDisable()
    {
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