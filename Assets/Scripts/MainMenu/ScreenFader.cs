using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class ScreenFader : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Image>().DOFade(0, 1f).OnComplete(() => gameObject.SetActive(false));
        }
    }
}