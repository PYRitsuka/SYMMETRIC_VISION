using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay.Story.UI
{
    public class TextBoxController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CanvasGroup canvasGroup;
        
        private string _currentFrameType = "旁白";
        private bool _isVisible = true;

        public void CrossFadeAnimatorState(string state, float duration)
        {
            if (_currentFrameType == state) return;
            animator.CrossFade(state, duration);
            _currentFrameType = state;
        }

        public void InterruptAnimatorState()
        {
            animator.CrossFade(_currentFrameType, 0);
        }

        private void Update()
        {
            if (!Input.anyKey) return;
            if (!CanHideCanvasGroup()) return;
            if (!Input.GetKeyDown(KeyCode.Backslash)) return;
            ToggleCanvasGroup();
        }

        private bool CanHideCanvasGroup()
        {
            return (canvasGroup.alpha != 0.0f || !_isVisible) && !ScriptResolver.IsJumping;
        }

        public void ToggleCanvasGroup()
        {
            if (Input.touchCount < 2) return;
            if (!CanHideCanvasGroup()) return;
            _isVisible = !_isVisible;
            ScriptResolver.BlockExecution.Value += _isVisible ? -1 : 1;
            canvasGroup.DOFade(_isVisible ? 1 : 0, .3f);
        }
    }
}