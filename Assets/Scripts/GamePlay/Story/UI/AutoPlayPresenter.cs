using DG.Tweening;
using UnityEngine;
using GamePlay.StoryV2;
namespace GamePlay.Story.UI
{
    public class AutoPlayPresenter : MonoBehaviour
    {
        [Header("关闭/开启的X坐标"), SerializeField] private Vector2 xPositions;
        [Header("触发按键"), SerializeField] private KeyCode autoKey;
        [Header("出现/消失速度，单位秒"), SerializeField] private float appearSpeed;
        [Header("出现/消失Ease方式"), SerializeField] private Ease appearEase;
        [Header("旋转速度，几秒一圈"), SerializeField] private float rotateSpeed;
        [Space(10), SerializeField] private RectTransform rotateTransform;
        
        private bool _isAutoPlay = false;

        private void Start()
        {
            rotateTransform.DORotate(new Vector3(0, 0, 360), rotateSpeed, RotateMode.FastBeyond360).SetEase(Ease.Linear)
                .SetLoops(-1);
            // ScriptResolver.CanSkip.PropertyChanged += delegate(bool b)
            // {
            //     if (b)
            //     {
            //         return;
            //     }
            //     if (_isAutoPlay)
            //     {
            //         ToggleAutoPlay();
            //     }
            // };
        }

        // void Update()
        // {
        //     return;
        // }

        public void SetVisible(bool v) {
            _isAutoPlay = v;
            GetComponent<RectTransform>().DOAnchorPosX(xPositions[_isAutoPlay ? 1 : 0], appearSpeed).SetEase(appearEase);
        }

        public void ToggleAutoPlay()
        {
            if (ScriptResolverV2.Instance.BlockExecution > 0  || GameObject.Find("/[Canvases][游戏主体部分]/文本框层").GetComponent<CanvasGroup>().alpha != 1)
            {
                Debug.Log("AUTO PLAY FAILED!");
                return;
            }
            SetVisible(ScriptResolverV2.Instance.isAutoPlay);
            // ScriptResolverV2.Instance.isAutoPlay = _isAutoPlay;
        }
        public void TAPForButton()
        {
            _isAutoPlay = !_isAutoPlay;
            ScriptResolver.IsAutoPlay = _isAutoPlay;
            GetComponent<RectTransform>().DOAnchorPosX(xPositions[_isAutoPlay ? 1 : 0], appearSpeed).SetEase(appearEase);
        }

        bool CheckUserInput()
        {
            return Input.GetKeyDown(autoKey);
        }

    }
}