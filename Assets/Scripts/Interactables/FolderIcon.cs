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
            OpenFolder();
        }

        private void OpenFolder()
        {
            targetFolder.SetActive(true);
        }
    }
}