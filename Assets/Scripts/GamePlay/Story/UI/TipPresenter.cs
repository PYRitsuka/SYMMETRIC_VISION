using DG.Tweening;
using UI.Common.ShaderProviders;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using XPostProcessing;
using GamePlay.StoryV2.Event;
using GamePlay.StoryV2;
namespace GamePlay.Story.UI
{
    public class TipPresenter : MonoBehaviourSingleton<TipPresenter>
    {
        [SerializeField] private Image url;
        [SerializeField] private RawImage tip;
        [SerializeField] private RawImage window;
        [SerializeField] private Button back;

        [SerializeField] public BlurShaderProvider _blurShaderProvider;
        [SerializeField] public ScriptResolverV2 scriptResolverV2;
        
        private Sequence _animationSequence;
        private bool _isOpened = false;

        public static bool IsReadingTips {get; private set;}
        public bool IsOpened { get => _isOpened; set => _isOpened = value; }

        private void Start()
        {
            // back.onClick.AddListener(delegate
            // {
            //     if (_isOpened)
            //     {
            //         Hide();
            //     }
            // });
        }

        public void Present(Texture tipTexture, Texture windowTexture)
        {
            Debug.Log("Tip Present!");
            url.sprite = UIModeController.Instance.GetCurrentUI().GetTipsURL();
            // if (_isOpened)
            // {
            //     return;
            // }
            tip.texture = tipTexture;
            window.texture = windowTexture;
            window.SetNativeSize();
            Show(windowTexture.height);
        }

        private void Update()
        {
            if (!_isOpened)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Hide();
                ScriptResolverV2.Instance.hasClick = true;
            }
        }

        // private void CloseTipPresenterIfNeeded(EventData x) {
        //     if (_isOpened) {
        //         Hide();
        //         x.StopPropagation = true;
        //         _isOpened = false;
        //         // tipPresenter.Hide();
        //     }
        //     // x.KeepOnComplete = true;
        // }

        private void Show(float windowHeight)
        {
            back.GetComponent<Image>().raycastTarget = true;
            _isOpened = true;
            //_postProcessVolume.enabled = true;
            IsReadingTips = true;
            _animationSequence = DOTween.Sequence();
            _animationSequence.SetAutoKill(false);
            _animationSequence.Append(DOTween.To(() => _blurShaderProvider.BlurSize,
                (x) => _blurShaderProvider.BlurSize = x,
                1, .3f));
            // _animationSequence.AppendCallback(()=>{
            //     scriptResolverV2.OnUserClick.Subscribe(CloseTipPresenterIfNeeded,7);
            // });
            _animationSequence.Append(url.rectTransform.DOAnchorPosY(434, .2f));
            _animationSequence.Append(window.rectTransform.DOAnchorPosY(445 - windowHeight, .4f));
            _animationSequence.Append(tip.DOFade(1, .3f));
            _animationSequence.Play();
            
        }

        public void Hide()
        {
            back.GetComponent<Image>().raycastTarget = false; // immediately drop hitbox
            _animationSequence.PlayBackwards();
            _isOpened = false;
            _animationSequence.OnStepComplete(delegate
            {
               
                
                IsReadingTips = false;
                //_postProcessVolume.enabled = false;
                // ScriptResolver.BlockExecution.Value--;
                _animationSequence.Kill();
            });
        }
    }
}