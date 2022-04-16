using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/Event")]
public class GameEventSO : ScriptableObject
{
    public UnityAction GameEvent { get; set; }

    public void RaiseEvent() => GameEvent?.Invoke();
    
}
