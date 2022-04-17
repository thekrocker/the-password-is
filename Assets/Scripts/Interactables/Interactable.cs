using UnityEngine;
using UnityEngine.EventSystems;

namespace Interactables
{
    public abstract class Interactable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked on me.. " + gameObject.name);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            
        }
    }
}
