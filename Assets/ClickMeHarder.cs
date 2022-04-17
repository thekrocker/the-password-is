using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClickMeHarder : MonoBehaviour
{
    public int clickCount;
    public int totalCount;

    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private TextMeshProUGUI topText;


    [SerializeField] private TextMeshProUGUI clickCountText;




    private Action ClickedEnough;


    private void SetClickCountText()
    {
        clickCountText.text = $"{clickCount}/{totalCount}";
    }

    private void SetTotalCount()
    {
        totalCount = Random.Range(7, 12);
    }

    private void Start()
    {
        SetTotalCount();
        SetClickCountText();
    }

    private void OnEnable()
    {
        ClickedEnough += SetText;
    }
    
    private void OnDisable()
    {
        ClickedEnough -= SetText;
    }

    private string myNumber = "951753963852741";

    private int _currentIndex;
    public void SetText()
    {
        SetTotalCount();
        if (_currentIndex >= myNumber.Length)
        {
            _Isfinished = true;
            topText.text = "İşte numaramı buldun.. Şimdi şifreyi terminalde gir..";
            return;
        }

        if (_firstTime)
        {
            _firstTime = false;
            numberText.text = "";
        }
        
        numberText.text += myNumber[_currentIndex];
        _currentIndex++;
    }

    private bool _firstTime = true;
    private bool _Isfinished;



    public void IncreaseClickCount()
    {
        if (_Isfinished) return;
        clickCount++;
        
        SetClickCountText();

        if (clickCount >= totalCount)
        {
            clickCount = 0;
            ClickedEnough?.Invoke();
        }
    }
}
