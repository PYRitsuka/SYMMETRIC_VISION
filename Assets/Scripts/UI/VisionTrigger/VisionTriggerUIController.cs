using System;
using DG.Tweening;
using GamePlay.Story;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
using GamePlay.StoryV2;
namespace UI.VisionTrigger
{
    public class VisionTriggerUIController : MonoBehaviour
    {
        [SerializeField] private RectTransform parent;
        [SerializeField] private RectTransform[] sides;
        [SerializeField] private Image bgImage;
        [SerializeField] private Image mergedImage;
        [SerializeField] private Image changedImage;
        [SerializeField] private GameObject expansionObject;
        [SerializeField] private Image[] expansionImages;
        [SerializeField] private AudioClip[] clips;
        [SerializeField] private RawImage screenshot;
        
        [SerializeField] private Sprite[] bgSprites;
        [SerializeField] private Sprite[] sideSprites;
        [SerializeField] private Sprite[] mergedSprites;
        [SerializeField] private Sprite[] changedSprites;
        [SerializeField] private Sprite[] expansionSprites;
        
        private Sequence _animationSequence;
        private float _factor;
        private Vector3 _cameraPosition;
        private AsyncOperation _operation;

        public static string NextScript;
        public static bool AutoOnLoad;
        public static int AnimationId = 1;
        public static Texture2D Screenshot;

        private void Start()
        {
            screenshot.texture = Screenshot;
            Play();
        }
        
        public void Play()
        {
            ScriptResolverV2.ScriptFileName = NextScript;
            ScriptResolverV2.AutoOnLoad = AutoOnLoad;
            // ScriptResolver.ReloadScript(StoryUtils.LoadResource<TextAsset>($"脚本/{NextScript}"), null);
            // ScriptResolver.SetCurrentNode($"脚本/{NextScript}");
            _operation = SceneManager.LoadSceneAsync("StoryScene", LoadSceneMode.Additive);
            _operation.allowSceneActivation = false;
            //ScriptResolver.OnLoad.AddListener(OnLoad);
            ScriptResolverV2.OnLoad.AddListener(OnLoad);
            
            _cameraPosition = Camera.main.transform.position;
            var t = Math.Clamp(AnimationId - 1, 0, 1);
            var inversedT = Math.Clamp(2 - AnimationId, 0, 1);
            if (AnimationId != 1)
            {
                sides[0].pivot = sides[1].pivot = Vector2.one;
                sides[0].DOAnchorPosY(1920f, 0f);
                sides[1].DOAnchorPosY(-1920f, 0f);
                bgImage.sprite = bgSprites[t];
                sides[0].GetComponent<Image>().sprite = sides[1].GetComponent<Image>().sprite = sideSprites[t];
                
            }
            
            _factor = AnimationId == 1 ? 1f : -1f;
            DOTween.defaultEaseType = Ease.OutQuad;
            _animationSequence = DOTween.Sequence();
            
            _animationSequence.Append(parent.DOLocalMoveY(-50, 1.5f)).Insert(0, parent.DOScale(.7f, 1.5f))
                .Insert(0, parent.DOLocalRotate(new Vector3(0, 0, 10f * _factor), 1.5f)).InsertCallback(0,
                    delegate { PlayClip(0); }).AppendInterval(1.5f).AppendCallback(delegate { PlayClip(1); });
            
            _animationSequence.Append(sides[0].DOLocalRotate(new Vector3(0, 0, 30f * _factor),.25f, RotateMode.LocalAxisAdd))
                .Insert(3f, sides[1].DOLocalRotate(new Vector3(0, 0, 30f * _factor),.25f, RotateMode.LocalAxisAdd));

            _animationSequence.AppendCallback(delegate
                {
                    mergedImage.gameObject.SetActive(true);
                    mergedImage.sprite = mergedSprites[t];
                    mergedImage.rectTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, -60f * _factor));
                })
                .Append(mergedImage.rectTransform.DOLocalRotate(new Vector3(0, 0, -10f * _factor), .25f));

            _animationSequence.AppendCallback(delegate
                {
                    changedImage.gameObject.SetActive(true);
                    changedImage.sprite = changedSprites[t];
                    parent.gameObject.SetActive(false);
                }).AppendInterval(.2f).AppendCallback(delegate { PlayClip(2); })
                .Append(changedImage.rectTransform.DOLocalRotate(new Vector3(0, 0, 180f * _factor), .5f));

            _animationSequence.AppendCallback(delegate
            {
                expansionObject.SetActive(true);
                changedImage.gameObject.SetActive(false);
                expansionImages[0].sprite = sideSprites[inversedT];
                expansionImages[1].sprite = expansionSprites[inversedT];
            }).AppendInterval(.5f);

            _animationSequence.Play();
            _animationSequence.OnStepComplete(delegate
            {
                _operation.allowSceneActivation = true;
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("StoryScene"));
            });
        }
        private void OnLoad()
        {
            Debug.Log("Vision Chang OnLoad Callback!");
            ScriptResolverV2.OnLoad.RemoveListener(OnLoad);
            PlayClip(3);
            var seq = DOTween.Sequence();
            seq.Append(expansionImages[0].rectTransform.DOLocalMoveY(-1600f, .3f))
                .Insert(0, expansionImages[1].rectTransform.DOLocalMoveY(1800f, .3f)).AppendInterval(1f).AppendCallback(
                    delegate
                    {
                        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("VisionTrigger"));
                    });
        }

        private void PlayClip(int index)
        {
            AudioSource.PlayClipAtPoint(clips[index], _cameraPosition);
        }
    }
}