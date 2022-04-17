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
        if (GameManager.Instance.currentPhaseIndex >= GameManager.Instance.PhaseDatas.Length) {return;}
        
        if (IsPasswordTrue())
        {
            PasswordSuccess.Invoke();
            ResetPasswordInput();
            Timer.Timer.Instance.StopTimer = true;
            Timer.Timer.Instance.isActive = false;
            
            AudioManager.Instance.PlayPasswordSuccess();
        }
        else // FAIL SCENEARIO.
        {
            if (passwordInput.Length > 0)
            {
                PasswordFailed.Invoke();
                GameManager.Instance.PasswordFailed = true;
                ResetPasswordInput();
                AudioManager.Instance.PlayPasswordFailed();
            }
            
            
        }
    }
    
    

    private bool IsPasswordTrue() => passwordInput.Equals(GameManager.Instance.GetCurrentPhase().currentPassword);

    private void ResetPasswordInput()
    {
        passwordInput = "";
    }
}
