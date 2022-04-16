using System;
using System.Collections;
using System.Globalization;
using Managers;
using SO;
using TMPro;
using UnityEngine;

namespace Timer
{
    public class Timer : Singleton<Timer>
    {
        public bool StopTimer { get; set; }
        public bool isActive;

        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private GameEventSO timerFinished;

        public void StartTimer(float elapsedTime)
        {
            if (isActive) return;
            isActive = true;
            
            const float totalTime = 0f;
                
            StartCoroutine(CO_StartTimer());

            IEnumerator CO_StartTimer()
            {
                timerText.enabled = true;
                    
                while (elapsedTime >= totalTime)
                {
                    if (StopTimer)
                    {
                        timerText.enabled = false;
                        yield break;
                    }
                    SetTimerText(elapsedTime);
                    elapsedTime -= Time.deltaTime;
                    elapsedTime -= SetTimePenalty(1f);
                    yield return null;
                }

                timerText.text = $"00:00";
                timerFinished.Invoke();
                Debug.Log("Timer finished...");
            }
        }

        private void SetTimerText(float elapsedTime)
        {
            int seconds = Mathf.FloorToInt(elapsedTime);
            timerText.text = $"{seconds}";
        }

        public float SetTimePenalty(float penalty)
        {
            if (!GameManager.Instance.PasswordFailed) return 0f;
            GameManager.Instance.PasswordFailed = false;
            return penalty;

        }
    }
    
    
}