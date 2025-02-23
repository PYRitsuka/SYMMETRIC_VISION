using DG.Tweening;
using UnityEngine;
using GamePlay.StoryV2;
namespace GamePlay.Story.UI
{
    public class SkipPresenter : MonoBehaviour
    {
        [Header("关闭/开启的X坐标"), SerializeField] private Vector2 xPositions;
        [Header("触发按键"), SerializeField] private KeyCode skipKey;
        [Header("出现/消失速度，单位秒"), SerializeField] private float appearSpeed;
        [Header("出现/消失Ease方式"), SerializeField] private Ease appearEase;
        [Header("旋转速度，几秒一圈"), SerializeField] private float rotateSpeed;
        [Space(10), SerializeField] private RectTransform rotateTransform;
        
        private bool _isSkipping = false;
        private float _timer = 0f;
        
        private const float SKIP_TIME = .5f;

        private void Start()
        {
            rotateTransform.DORotate(new Vector3(0, 0, 360), rotateSpeed, RotateMode.FastBeyond360).SetEase(Ease.Linear)
                .SetLoops(-1);
        }


        public void ToggleSkip()
        {
            _isSkipping = ScriptResolverV2.Instance.isSkipping;
            GetComponent<RectTransform>().DOAnchorPosX(xPositions[_isSkipping ? 1 : 0], appearSpeed).SetEase(appearEase);
        }
    }
}