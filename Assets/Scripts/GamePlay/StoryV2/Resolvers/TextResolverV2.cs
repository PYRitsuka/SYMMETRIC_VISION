using System;
using System.Text;
using System.Threading.Tasks;
using Baracuda.Threading;
using Constants;
using DG.Tweening;
using GamePlay.Story.Backlog;
using GamePlay.Story.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Text = GamePlay.Story.Record.Text;
using System.Text.RegularExpressions;
using GamePlay.StoryV2.Event;
namespace GamePlay.StoryV2.RecordsResolver
{
    public class TextResolverV2 : MonoBehaviourSingleton<TextResolverV2>
    {
        [Space(10), SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text dialogText;
        [SerializeField] private RawImage avatar;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextBoxController textBoxController;
        [SerializeField] public TipGrid tipLoader;

        public float currSpeed = 30.0f;


        public int fontSize = 32;

        private float displayedCnt = 0;

        public void OnPointerClick(EventData eventData)
        {
            Debug.Log($"Text:OnPointerClick!!");
            
            if (TipPresenter.Instance.IsOpened) {
                return;
            }
            Debug.Log($"Text:OnPointerClick2!!");
            eventData.KeepOnComplete = true;
            // Vector2 point = (Camera.main).ScreenToViewportPoint(Input.mousePosition) * new Vector2(1920, 1080);
            var index = TMP_TextUtilities.FindIntersectingLink(dialogText, Input.mousePosition, Camera.main);
            Debug.Log($"Index: {index}");
            if (index == -1)
            {
                return;
            }
            
            var linkID = dialogText.textInfo.linkInfo[index].GetLinkID();
            var windowTexture = StoryUtils.LoadResource<Texture>($"Tips/TipsWindow_{linkID}.png");
            var tipTexture = StoryUtils.LoadResource<Texture>($"Tips/Tips_{linkID}.png");
            //ScriptResolver.IsMouseOverTips = false;
            // hasClick = true; // just block one propagation
            //TipPresenter.Instance.Present(tipTexture, windowTexture);
            eventData.StopPropagation = true;
            
        }

        private void SetDisplayedCnt(float v) {
            displayedCnt = v;
            dialogText.maxVisibleCharacters = Convert.ToInt32(v);
        }

        private float GetDisplayedCnt() {
            return displayedCnt;
        }
        
        

        public Tween Display(float speed) {
            var maxCnt = dialogText.GetTextInfo(dialogText.text).characterCount;
            if (speed == -1){
                speed = currSpeed;
            }
            if (speed == 9999 ) {
                SetDisplayedCnt(maxCnt+1);
                return null;
            }
            speed *= 2 * MathF.Pow(2, PlayerPrefs.GetFloat("textAppearSpeed", SettingsConstants.TextAppearSpeed));

            
            SetDisplayedCnt(0);
            var animation = DOTween.To(GetDisplayedCnt, SetDisplayedCnt, maxCnt+1, maxCnt * 1f / speed);
            animation.OnKill(
                    ()=>animation.Complete(true)
            );
            return animation;
        }

        public string ResolveLinks(string text)
        {
            var ret = new StringBuilder();
            while (true)
            {
                var ind = text.IndexOf("<link=", StringComparison.Ordinal);
                if (ind == -1)
                {
                    break;
                }
                ret.Append(text.Substring(0, ind - 1));
                ret.Append("<style=link>");
                var ind2 = text.IndexOf("</link>", StringComparison.Ordinal);
                ret.Append(text.Substring(ind, ind2 - ind + 7));
                var slice = text.Substring(ind, ind2 - ind + 7);
                var matched = ExtractLinkValue(slice);
                Debug.Log($"FMT::: {slice} :::{matched}");
                if (matched != null && !ScriptResolverV2.Instance.isSkipping && !ScriptResolverV2.Instance.IsFastForwarding() ) {
                    tipLoader.AddImage(matched);
                    //ScriptResolver.Instance.ShowTips(matched);
                }
                ret.Append("</style>");
                text = text.Substring(ind2 + 7);
            }
            ret.Append(text);
            return ret.ToString();
        }
        public static string ExtractLinkValue(string input)
        {
            // Define the regex pattern to match <link=xxx>
            string pattern = @"<link=(.*?)>";

            // Create a regex object
            Regex regex = new Regex(pattern);

            // Match the input string
            Match match = regex.Match(input);

            // Check if the match is successful
            if (match.Success)
            {
                // Extract the value inside the link tag
                string value = match.Groups[1].Value;
                return value;
            }
            else
            {
                // Handle the case where no match is found
                return null;
            }
        }

        public Tween TransitAlpha(float alphaBegin,float alphaEnd,float duration)
        {
            if (alphaEnd > 0) {
                canvasGroup.interactable = true;
            } else {
                canvasGroup.interactable = false;
            }
            if (duration == 0)
            {
                canvasGroup.alpha = alphaEnd;
                return null;
            }
            else
            {
                canvasGroup.alpha = alphaBegin;
                var animation = canvasGroup.DOFade(alphaEnd, duration);
                animation.OnKill(
                    ()=>animation.Complete(true)
                );
                return animation;
            }

            //ScriptResolver.WaitTime.Value = duration;
        }

        string GetFrameType(string frameName)
        {
            if (frameName.Contains("dialogue"))
                return "台词";
            if (frameName.Contains("avatar"))
                return "头像";
            if (frameName.Contains("narration"))
                return "旁白";
            return null;
        }

        public void ChangeFrameType(string type)
        {
            if(string.IsNullOrEmpty(type)) return;
            textBoxController.CrossFadeAnimatorState(GetFrameType(type), 0.1f);
        }

        public string GetCurrentText() {
            return dialogText.text;
        }

        public void ChangeContent(string charName, string dialog, string avatarPath)
        {
            tipLoader.FadeAllImages();
            int textSize = fontSize;
            nameText.text = charName;
            dialog = ResolveLinks(dialog);
            dialogText.text = dialog;
            dialogText.fontSize = textSize;
            dialogText.maxVisibleCharacters = 0;
            BacklogManager.Instance.AppendLog(charName, dialog);
            if (string.IsNullOrEmpty(avatarPath))
            {
                //avatar.texture = null;
                //avatar.color = Color.clear;
                return;
            }

            var tex = StoryUtils.LoadResource<Texture>($"文本框/{avatarPath}");
            avatar.texture = tex;
            avatar.color = Color.white;
            avatar.SetNativeSize();
            if (tex == null)
            {
                avatar.color = Color.clear;
            }
        }
        

    }
}