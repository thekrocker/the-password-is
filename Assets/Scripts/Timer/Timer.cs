using System;
using System.Collections;
using System.Globalization;
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
                    var seconds = Mathf.FloorToInt(elapsedTime);
                    if (seconds.ToString().Length > 1) timerText.text = $"00:{seconds}";
                    else timerText.text = $"00:0{seconds}";

                    if (StopTimer)
                    {
                        timerText.enabled = false;
                        Debug.Log("Timer stopped.. Succesful");
                        yield break;
                    }

                    elapsedTime -= Time.deltaTime;
                    Debug.Log(elapsedTime);
                    yield return null;
                }

                timerText.text = $"00:00";
                timerFinished.Invoke();
                Debug.Log("Timer finished...");
            }
        }
    }
}