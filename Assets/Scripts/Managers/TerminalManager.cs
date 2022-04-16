using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TerminalManager : MonoBehaviour
{
    public string passwordInput;
    
    [Title("Passwords")]
    [SerializeField] private PasswordData[] passwordDatas;
    
    [Title("Actions")] 
    [SerializeField] private GameEventSO PasswordSuccess;
    [SerializeField] private GameEventSO PasswordFailed;


    private int _currentPhaseIndex = 0;
    
    public void ReadPasswordInput(string input) // Reads when pressed enter in field..
    {
        passwordInput = input;
        Debug.Log($"Password entry: {passwordInput}");
        CheckPassword();
    }

    
    private void CheckPassword()
    {
        if (_currentPhaseIndex >= passwordDatas.Length) return;
        
        if (IsPasswordTrue())
        {
            Debug.Log("True!");
            PasswordSuccess.RaiseEvent();
            
            ChangePhase();
            ResetPasswordInput();

        }
        else // FAIL SCENEARIO.
        {
            Debug.Log("False password!");
            PasswordFailed.RaiseEvent();
            
            ResetPasswordInput();

        }
    }

    private bool IsPasswordTrue() => passwordInput.Equals(passwordDatas[_currentPhaseIndex].currentPassword);
    private void ChangePhase()
    {
        _currentPhaseIndex++;
    }

    private void ResetPasswordInput()
    {
        passwordInput = "";
    }
}
