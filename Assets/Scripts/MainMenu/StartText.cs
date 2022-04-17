using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class StartText : MonoBehaviour
{
   
   private TextMeshProUGUI startText;
    void Start()
    {
        startText = GetComponent<TextMeshProUGUI>();

        startText.DOFade(0, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
    
    private void OnDestroy() => startText.DOKill();
}
