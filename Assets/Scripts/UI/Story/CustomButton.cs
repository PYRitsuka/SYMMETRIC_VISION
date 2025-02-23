using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Story
{
    public class CustomButton : Button
    {
        private readonly Vector2 _size = new Vector2(1, 1.2f);
        private const float Duration = .2f;

        public override void OnPointerEnter(PointerEventData eventData)
        {
            GetComponent<RectTransform>().DOScale(new Vector3(_size.y, _size.y, _size.y), Duration);
            base.OnPointerEnter(eventData);
        }
        
        public override void OnPointerExit(PointerEventData eventData)
        {
            GetComponent<RectTransform>().DOScale(new Vector3(_size.x, _size.x, _size.x), Duration);
            base.OnPointerExit(eventData);
        }
    }
}
