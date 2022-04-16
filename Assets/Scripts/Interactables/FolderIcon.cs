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

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            if (GameManager.Instance.IsGameOver) return;
            if (targetFolder != null) OpenFolder();
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