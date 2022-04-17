using System;
using DG.Tweening;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interactables
{
    public class FolderIcon : Interactable
    {
        [SerializeField] private GameObject targetFolder;
        [SerializeField] private GameObject bgHighlighter;
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            if (GameManager.Instance.IsGameOver) return;
            if (targetFolder != null)
            {
                AudioManager.Instance.PlayClickSound();
                OpenFolder();
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            bgHighlighter.SetActive(true);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            bgHighlighter.SetActive(false);
        }

        private void OpenFolder()
        {
            targetFolder.SetActive(true);
            targetFolder.transform.localScale = Vector3.zero;
            targetFolder.transform.DOScale(Vector3.one, 0.2f);
        }

        private void OnDisable() => targetFolder.transform.DOKill();
    }
}