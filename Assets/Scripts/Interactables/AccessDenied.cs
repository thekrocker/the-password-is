using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Interactables
{
    public class AccessDenied : MonoBehaviour
    {
        private void OnEnable() => CloseAccesPanel();

        private void CloseAccesPanel()
        {

            StartCoroutine(CO_CloseAccessPanel());
            IEnumerator CO_CloseAccessPanel()
            {
                yield return new WaitForSeconds(1.5f);
                transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InQuad).OnComplete(() => gameObject.SetActive(false));

            }
        }

        private void OnDisable()
        {
            transform.DOKill();
        }
    }
    
    
}
