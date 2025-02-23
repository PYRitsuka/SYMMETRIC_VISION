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
namespace GamePlay.Story.RecordsResolver
{
    public class TextResolver : MonoBehaviourSingleton<TextResolver>, IResolvable
    {
        [Space(10), SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text dialogText;
        [SerializeField] private RawImage avatar;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextBoxController textBoxController;

        private Text _currentData;

        private const float TimePerWord = .07f;

        public bool _isJumpingText;

        public static string CurrentText = "";

        public void Resolve(object data)
        {
            while (_isJumpingText)
            {
                if (!_isJumpingText)
                    break;
                continue;
            }
            _currentData = data as Text;
            if (_currentData == null)
            {
                Debug.LogError("文本操作数据读取失败");
                return;
            }

            ChangeFrameType(GetFrameType(_currentData.DialogBoxPicture));

            _currentData.TextContent = ResolveLinks(_currentData.TextContent);
            CurrentText = _currentData.TextContent;
            _currentData.TextSpeed *= MathF.Pow(2, PlayerPrefs.GetFloat("textAppearSpeed", SettingsConstants.TextAppearSpeed));
            _currentData.TextSpeed *= 2;
            BacklogManager.Instance.AppendLog(_currentData.CharacterName, _currentData.TextContent);
            
            ChangeContent(_currentData.CharacterName, _currentData.TextContent, _currentData.CharacterIcon,
                _currentData.TextSize);

            TransitAlpha();

            var maxCnt = dialogText.GetTextInfo(_currentData.TextContent).characterCount;
            ScriptResolver.ExtraAutoWaitTime = 0.5f * maxCnt * TimePerWord / MathF.Pow(2, PlayerPrefs.GetFloat("autoPlaySpeed", SettingsConstants.AutoPlaySpeed));
            if (ScriptResolver.ExtraAutoWaitTime < 1.5f / MathF.Pow(2, PlayerPrefs.GetFloat("autoPlaySpeed", SettingsConstants.AutoPlaySpeed)))
                ScriptResolver.ExtraAutoWaitTime = 1.5f / MathF.Pow(2, PlayerPrefs.GetFloat("autoPlaySpeed", SettingsConstants.AutoPlaySpeed));
            JumpText(maxCnt, _currentData.TextSpeed);
            ScriptResolver.WaitTime.Value = maxCnt * 1f / _currentData.TextSpeed + 0.08f;
        }

        public static void BlockRaycasts(bool disabled)
        {
            Instance.canvasGroup.blocksRaycasts = !disabled;
        }

        string ResolveLinks(string text)
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
                if (matched != null) {
                    ScriptResolver.Instance.ShowTips(matched);
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
        void TransitAlpha()
        {
            if (string.IsNullOrEmpty(_currentData.AlphaTransition))
            {
                return;
            }
            var list = _currentData.AlphaTransition.SplitSemicolon();
            if (list.Count < 3)
            {
                Debug.LogError("Invalid alpha text command: " + _currentData.AlphaTransition);
                return;
            }
            
            var duration = list[2].ToFloat();
            if (duration == 0)
            {
                canvasGroup.alpha = list[1].ToFloat();
            }
            else
            {
                canvasGroup.alpha = list[0].ToFloat();
                canvasGroup.DOFade(list[1].ToFloat(), duration);
            }

            ScriptResolver.WaitTime.Value = duration;
        }

        string GetFrameType(string frameName)
        {
            if (frameName.Contains("台词"))
                return "台词";
            if (frameName.Contains("头像"))
                return "头像";
            if (frameName.Contains("旁白"))
                return "旁白";
            return null;
        }

        void ChangeFrameType(string type)
        {
            textBoxController.CrossFadeAnimatorState(type, 0.1f);
        }

        void ChangeContent(string charName, string dialog, string avatarPath, int textSize)
        {
            nameText.text = charName;
            dialogText.text = dialog;
            dialogText.fontSize = textSize;
            dialogText.maxVisibleCharacters = 0;
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
        
        async void JumpText(int maxCnt, float speed)
        {
            _isJumpingText = true;
            var secBetweenChar = 1f / speed;
            var token = ScriptResolver.CancellationTokenSource.Token;
            var i = 0;
            while (i < maxCnt)
            {
                i++;
                var i1 = i;
                await Dispatcher.InvokeAsync((Action) (() => dialogText.maxVisibleCharacters = i1));
                await Task.WhenAny(Task.Delay((int)(secBetweenChar * 1000), token));
                if (!token.IsCancellationRequested)
                {
                    continue;
                }
                break;
            }
            textBoxController.InterruptAnimatorState();
            await Dispatcher.InvokeAsync((Action)(() => dialogText.maxVisibleCharacters = maxCnt));
            _isJumpingText = false;
        }
    }
}