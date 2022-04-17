using System.Collections;
using System.Collections.Generic;
using Interactables;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeedAreaUnlocker : Interactable
{
    public GameObject speedArea;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        speedArea.SetActive(true);
    }
}
