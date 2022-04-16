using UnityEngine;
using UnityEngine.Events;

namespace SO
{
    [CreateAssetMenu(menuName = "GameEvents/Event")]
    public class GameEventSO : ScriptableObject
    {
        public UnityAction GameEvent { get; set; }

        public void RaiseEvent() => GameEvent?.Invoke();
    
    }
}
