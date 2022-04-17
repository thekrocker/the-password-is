using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Image screenFader;

    private Button startButton;
    void Start()
    {
        startButton = GetComponent<Button>();
        
        startButton.onClick.AddListener(SetNextScene);
    }

    private void SetNextScene()
    {
        //@TODO: Sound maybe...
        startButton.enabled = false;
        screenFader.gameObject.SetActive(true);
        screenFader.DOFade(1, 2f).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
    }

    private void OnDestroy()
    {
        screenFader.DOKill();
    }
}
