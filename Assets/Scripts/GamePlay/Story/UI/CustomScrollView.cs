using System;
using System.Collections.Generic;
using DG.Tweening;
using GamePlay.Story.RecordsResolver;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GamePlay.Story.UI
{
    public class CustomScrollView : MonoBehaviour
    {
        [SerializeField] private GraphicRaycaster gr;
        [SerializeField] private RawImage image;
        [SerializeField] private GameObject detectObject;

        private bool _isOverViewer;
        private Vector2 _wh;

        private void Update()
        {
            if (IsOverViewer())
            {
                if (!_isOverViewer)
                {
                    ScriptResolver.BlockExecution.Value++;
                    Debug.Log("++");
                    _isOverViewer = true;
                    TextResolver.BlockRaycasts(true);
                }
            }
            else if (_isOverViewer)
            {
                ScriptResolver.BlockExecution.Value--;
                Debug.Log("--");
                _isOverViewer = false;
                TextResolver.BlockRaycasts(false);
            }
        }

        private bool IsOverViewer()
        {
            var pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };
            var results = new List<RaycastResult>();
            gr.Raycast(pointerEventData, results);
            return results.Exists(x => x.gameObject == detectObject);
        }

        public void Setup(Texture texture, int width, int height)
        {
            _wh = new Vector2(width, height);
            image.texture = texture;
            image.SetNativeSize();
        }

        public void DOScale(float from, float to, float duration)
        {
            if (duration == 0)
            {
                GetComponent<RectTransform>().sizeDelta = _wh * to;
            }
            else
            {
                var rt = GetComponent<RectTransform>();
                rt.sizeDelta = _wh * from;
                rt.DOSizeDelta(_wh * to, duration);
            }
        }

        public RawImage GetRawImageComponent() => image;
    }
}