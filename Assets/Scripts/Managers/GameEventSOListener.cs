using System;
using SO;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class GameEventSOListener : MonoBehaviour
    {
        [SerializeField] private GameEventSO gameEvent;
        [SerializeField] private UnityEvent response;
        
        
        private void OnEnable() => gameEvent.Add(this);
        private void OnDisable() => gameEvent.Remove(this);

        public void Invoke() => response?.Invoke();
    }
    
}