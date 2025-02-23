using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Common;
using GamePlay.Story.RecordsResolver;
using GamePlay.StoryV2;
using GamePlay.StoryV2.RecordsResolver;
using Newtonsoft.Json;
using Save;
using Serializable;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace GamePlay.Story.UI
{
    public class SaveController : MonoBehaviour
    {
        [SerializeField] private Image frameImage;
        [SerializeField] private Image previewImage;
        [SerializeField] private Text chapterNumberText;
        [SerializeField] private Text dateText;
        [SerializeField] private TMP_Text chapterNameText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private List<Sprite> frames;

        private Button _saveButton;
        private StorySave _bindingSave;
        private bool _isDirty = false;
        private string _fileName = SaveManager.NullSaveIndicator;

        public const string DateTimeFormat = "yyyy.M.d H:mm";
        private const string ChapterNumberFormat = "CHAPTER {0}.";
        

        void Start()
        {
            _saveButton = GetComponent<Button>();
            _saveButton.onClick.AddListener(delegate
            {
                SaveLoadUIManager.Instance.hasClick = true;
                // SaveLoadModalWindow.Instance.Show();
                StartCoroutine(SaveLoadUIManager.Instance.CurrentType == SaveLoadUIManager.SaveLoad.Save
                    ? Save()
                    : Load());
            });
            frameImage.sprite = frames[UIModeController.Instance.GetCurrentUIIndex()];
        }
        
        public void Bind(StorySave save)
        {
            _bindingSave = save;
            ReloadContent();
            // SetDirty();
        }

        // private void Update()
        // {
        //     if (!_isDirty) return;
        //     ReloadContent();
        //     _isDirty = false;
        // }

        IEnumerator Save()
        {
            if (_fileName != SaveManager.NullSaveIndicator)
            {
                SaveLoadModalWindow.Instance.Show();
                yield return new WaitUntil(() => SaveLoadModalWindow.IsOpen == false);
                if (!SaveLoadModalWindow.IsConfirmed)
                {
                    yield break;
                }
            }
            // SetDirty();
            SaveLoadUIManager.Instance.Hide(delegate
            {
                var save = new StorySave
                {
                    chapterNumber = ScriptResolverV2.ChapterNumber,
                    chapterName = ScriptResolverV2.ChapterName,
                    saveTime = DateTime.Now.ToString(DateTimeFormat),
                    scriptLine = ScriptResolverV2.ScriptLine,
                    scriptName = ScriptResolverV2.ScriptFileName,
                    lastCheckpoint = ScriptResolverV2.lastCheckpoint,
                    text = TextResolverV2.Instance.GetCurrentText(),
                    uiMode = UIModeController.Instance.GetCurrentUIIndex(),
                    globalFlag = ScriptResolverV2.Instance.globalState,
                };
                StartCoroutine(SaveCoroutine(save));
            });
        }
        
        IEnumerator Load()
        {
            Debug.Log("LoadManager, PopUp, Show");
            SaveLoadModalWindow.Instance.Show();
             Debug.Log("LoadManager, PopUp Done");
            yield return new WaitUntil(() => SaveLoadModalWindow.IsOpen == false);
            Debug.Log($"LoadManager, Confirmed? {SaveLoadModalWindow.IsConfirmed}");
            if (!SaveLoadModalWindow.IsConfirmed) yield break;
            if (ScriptResolverV2.Instance != null) {
                ScriptResolverV2.Instance.BlockExecution++;
                //ScriptResolverV2.Instance.audioResolver.StopManually();
                ScriptResolverV2.Instance.audioResolver.PlayBlank();
            }
            SaveLoadUIManager.Instance.Hide(delegate
            {
                //Perform load operation...
                // var asset = StoryUtils.LoadResource<TextAsset>($"脚本/{_bindingSave.scriptName}");
                //ScriptResolver.Instance.ResetStoryCanvas();
                ScriptResolverV2.ScriptFileName = _bindingSave.scriptName;
                ScriptResolverV2.TargetLine = _bindingSave.scriptLine;
                ScriptResolverV2.loadedState = _bindingSave.globalFlag;
                ScriptResolverV2.loadLastCheckpoint = _bindingSave.lastCheckpoint;
                Debug.Log($"Called Load! {ScriptResolverV2.ScriptFileName} {ScriptResolverV2.TargetLine} {ScriptResolverV2.loadedState}");
                // ScriptResolver.ReloadScript(asset, _bindingSave.userSelections, _bindingSave.scriptLine);
                _ = SceneTransit.Instance.TransitTo("StoryScene");
            });
        }
        
        private IEnumerator SaveCoroutine(StorySave save)
        {
            yield return new WaitForEndOfFrame();
            var width = Screen.width;
            var height = Screen.height;
            var startX = 0;
            var startY = 0;
            if (1f * width / height > 1.7778f /* 9/16 */)
            {
                width = height / 9 * 16;
                startX = (Screen.width - width) / 2;
            }
            else
            {
                height = width / 16 * 9;
                startY = (Screen.height - height) / 2;
            }
            var screenImage = new Texture2D(width, height);
            screenImage.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
            screenImage.Apply();
            screenImage = screenImage.ResizeTexture(282, 158);
            var bytes = screenImage.EncodeToPNG();
            var base64 = Convert.ToBase64String(bytes);
            save.screenshot = base64;
            SaveManager.Save(save, _fileName);
        }

        private void ReloadContent()
        {
            if (_bindingSave == null)
            {
                return;
            }
            _fileName = _bindingSave.fileName;
            frameImage.sprite = frames[_bindingSave.uiMode];
            previewImage.sprite = _bindingSave.previewSprite;
            chapterNumberText.color = UIModeController.Instance.GetUIByIndex(_bindingSave.uiMode).GetMainColor();
            chapterNumberText.text = string.Format(ChapterNumberFormat, _bindingSave.chapterNumber);
            chapterNameText.text = _bindingSave.chapterName;
            dateText.text = _bindingSave.saveTime;
            descriptionText.text = _bindingSave.text;
        }

        // private void SetDirty()
        // {
        //     _isDirty = true;
        // }
    }
}