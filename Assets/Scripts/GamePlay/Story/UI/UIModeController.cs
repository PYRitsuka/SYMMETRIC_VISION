using System;
using System.Collections.Generic;
using Common;
using GamePlay.Story.Backlog;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace GamePlay.Story.UI
{
    public class UIModeController : MonoBehaviourSingleton<UIModeController>
    {
        
        [Header("UI部分"),SerializeField] private RawImage frame;
        [SerializeField] private RawImage framer;
        [SerializeField] private RawImage framel;
        [SerializeField] private RawImage nameFrame;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private RawImage autoFrame;
        [SerializeField] private Image autoMark;
        [SerializeField] private RawImage skipFrame;
        [SerializeField] private Image skipMark;
        [SerializeField] private Image gameHelp;
        [SerializeField] private Image backlogFrame;
        [SerializeField] private Image backlogPromptFrame;
        [SerializeField] private Image backlogScrollbar;
        [SerializeField] private Image saveLoadScrollbar;
        [Space(13), SerializeField] private List<StoryUI> uiModes;

        private int _currentIndex = 5;
        
        public void SetUIMode(int index)
        {
            _currentIndex = index;
            var mode = uiModes[index];
            frame.texture = mode.GetFrame();
            framer.texture = mode.GetFrameR();
            framel.texture = mode.GetFrameL();
            nameFrame.texture = mode.GetNameFrame();
            nameText.color = mode.GetNameColor();
            autoFrame.texture = mode.GetAutoFrame();
            autoMark.sprite = mode.GetAutoMark();
            skipFrame.texture = mode.GetSkipFrame();
            skipMark.sprite = mode.GetSkipMark();
            gameHelp.sprite = mode.GetGameHelp();
            backlogFrame.sprite = mode.GetBacklogFrame();
            backlogPromptFrame.sprite = mode.GetBacklogPromptFrame();
            backlogScrollbar.sprite = mode.GetBacklogScrollbar();
            saveLoadScrollbar.sprite = mode.GetBacklogScrollbar();
            BacklogManager.Instance.ResetColor();
        }

        public StoryUI GetCurrentUI() => uiModes[_currentIndex];

        public static T GetCurrentUIElementByFieldName<T>(string name)
        {
            var type = typeof(StoryUI);
            var currentUI = Instance.GetCurrentUI();
            // Try to get a property
            var propertyInfo = type.GetProperty(name);
            if (propertyInfo != null)
            {
                return (T) propertyInfo.GetValue(currentUI);
            }

            // Try to get a field
            var fieldInfo = type.GetField(name);
            if (fieldInfo != null)
            {
                return (T) fieldInfo.GetValue(currentUI);
            }

            // If neither found, return null
            return default(T);
        }

        public int GetCurrentUIIndex() => _currentIndex;
        
        public StoryUI GetUIByIndex(int index) => uiModes[index];
    }
}