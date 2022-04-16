using System;
using Sirenix.OdinInspector;
using SO;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        [Title("Actions")] 
        [SerializeField] private GameEventSO OnPasswordSuccess;
        [SerializeField] private GameEventSO OnPasswordFailed;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }


        private void OnEnable()
        {
            OnPasswordSuccess.GameEvent += IncreasePhase;
        }

        private void OnDisable() => OnPasswordSuccess.GameEvent -= IncreasePhase;

        public int CurrentPhaseIndex { get; set; }

        public void IncreasePhase()
        {
            CurrentPhaseIndex++;
        }
    }
}