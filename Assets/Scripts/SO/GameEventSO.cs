using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace SO
{
    [CreateAssetMenu(menuName = "GameEvents/Event")]
    public class GameEventSO : ScriptableObject
    {
        private List<GameEventSOListener> _listeners = new List<GameEventSOListener>();

        public void Add(GameEventSOListener listener) => _listeners.Add(listener);
        public void Remove(GameEventSOListener listener) => _listeners.Remove(listener);

        public void Invoke()
        {
            foreach (GameEventSOListener listener in _listeners) listener.Invoke();
        }

    }
}
