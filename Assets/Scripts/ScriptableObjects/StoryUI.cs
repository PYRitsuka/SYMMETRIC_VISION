using System.Collections.Generic;
using GamePlay.Story.UI;
using UnityEngine;
using Common;
namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "创建一个游戏内UI")]
    public class StoryUI : ScriptableObject
    {
        [Header("对话框"), SerializeField]
        private Texture m_frame;
    
        [Header("对话框右边"), SerializeField]
        private Texture m_framer;
    
        [Header("对话框左边"), SerializeField]
        private Texture m_framel;

        [Header("姓名框"), SerializeField]
        private Texture m_nameFrame;
        
        [Header("姓名颜色"), SerializeField]
        private Color m_nameColor;

        [Header("Tips网址框"), SerializeField]
        private Sprite m_tipsURL;

        [Header("Auto框"), SerializeField]
        private Texture m_autoFrame;
        
        [Header("Auto中间三角形"), SerializeField]
        private Sprite m_autoMark;
        
        [Header("Skip框"), SerializeField]
        private Texture m_skipFrame;
                
        [Header("Skip中间三角形"), SerializeField]
        private Sprite m_skipMark;

        [Header("Help框架"), SerializeField]
        private Sprite m_gamehelp;


        [Header("Help框架_Mobile"), SerializeField]
        private Sprite m_gamehelpMobile;

        [Header("Backlog框架"), SerializeField]
        private Sprite m_backlogFrame;
        
        [Header("Backlog提示"), SerializeField]
        private Sprite m_backlogPromptFrame;

        [Header("Backlog提示(PC)"), SerializeField]
        private Sprite m_backlogPromptFrame_PC;
        
        [Header("Backlog滚动条"), SerializeField]
        private Sprite m_backlogScrollbar;
        
        [Header("Backlog的log背景"), SerializeField]
        private Sprite m_logBackground;
        
        [Header("Save框架"), SerializeField]
        private Sprite m_saveFrame;
        
        [Header("Load框架"), SerializeField]
        private Sprite m_loadFrame;

        [Header("右键菜单框架"), SerializeField]
        private Sprite m_contextMenu;
        
        [Header("UI主色"), SerializeField]
        private Color m_mainColor;

        //啊啊啊烦死了再也不写property了 操 public盘他
        public Sprite settingBg;
        public Sprite settingSlideBar;
        public Sprite settingConfirmButton;
        public Sprite settingResetButton;
        public Sprite settingSwitchButton;
        public Sprite selectionBackground;
        public Sprite StorylineTitle;

        public Sprite StorylineTitle_PC;

        public Sprite StorylineTitle_Auto  {
            get { return  MobilePlatformScriptController.isMobile?StorylineTitle:StorylineTitle_PC; }
        }
        public Sprite StorylineCP;

        public Texture GetFrame() => m_frame;

        public Texture GetFrameR() => m_framer;

        public Texture GetFrameL() => m_framel;

        public Texture GetNameFrame() => m_nameFrame;
        
        public Color GetNameColor() => m_nameColor;
        
        public Sprite GetTipsURL() => m_tipsURL;
        
        public Texture GetAutoFrame() => m_autoFrame;

        public Sprite GetAutoMark() => m_autoMark;

        public Texture GetSkipFrame() => m_skipFrame;

        public Sprite GetSkipMark() => m_skipMark;

        public Sprite GetGameHelp() => MobilePlatformScriptController.isMobile? m_gamehelpMobile: m_gamehelp;

        public Sprite GetBacklogFrame() => m_backlogFrame;
        
        public Sprite GetBacklogPromptFrame() => MobilePlatformScriptController.isMobile? m_backlogPromptFrame: m_backlogPromptFrame_PC;
        
        public Sprite GetBacklogScrollbar() => m_backlogScrollbar;
        
        public Sprite GetLogBackground() => m_logBackground;
        
        public Sprite GetSaveFrame() => m_saveFrame;

        public Sprite GetLoadFrame() => m_loadFrame;
        
        public Sprite GetContextMenu() => m_contextMenu;

        public Color GetMainColor() => m_mainColor;
    }
}