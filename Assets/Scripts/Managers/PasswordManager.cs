using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Sirenix.OdinInspector;
using SO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PasswordManager : MonoBehaviour
{
    public string passwordInput;
    
    [Title("Passwords")]
    [SerializeField] private PhaseData[] passwordDatas;
    
    [Title("Actions")] 
    [SerializeField] private GameEventSO PasswordSuccess;
    [SerializeField] private GameEventSO PasswordFailed;
    
    
    public void ReadPasswordInput(string input) // Reads when pressed enter in field..
    {
        passwordInput = input;
        Debug.Log($"Password entry: {passwordInput}");
        CheckPassword();
    }
    
    private void CheckPassword()
    {
        if (GameManager.Instance == null) return;
        if (GameManager.Instance.CurrentPhaseIndex >= passwordDatas.Length) return;
        
        if (IsPasswordTrue())
        {
            PasswordSuccess.Invoke();
            ResetPasswordInput();
            Timer.Timer.Instance.StopTimer = true;
            Timer.Timer.Instance.isActive = false;
        }
        else // FAIL SCENEARIO.
        {
            if (passwordInput.Length > 0)
            {
                PasswordFailed.Invoke();
                ResetPasswordInput();
            }
        }
    }
    
    

    private bool IsPasswordTrue() => passwordInput.Equals(passwordDatas[GameManager.Instance.CurrentPhaseIndex].currentPassword);

    private void ResetPasswordInput()
    {
        passwordInput = "";
    }
}
