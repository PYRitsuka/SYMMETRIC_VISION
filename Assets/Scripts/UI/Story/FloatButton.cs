using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Story
{
    public class FloatButton : Button
    {
        public UnityEvent onPointerEnter;
        public UnityEvent onPointerExit;
        
        
        public override void OnPointerEnter(PointerEventData eventData)
        {
            onPointerEnter.Invoke();
            base.OnPointerEnter(eventData);
        }
        
        public override void OnPointerExit(PointerEventData eventData)
        {
            onPointerExit.Invoke();
            base.OnPointerExit(eventData);
        }
    }
}