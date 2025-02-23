using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "存档创建")]
    public class Save : ScriptableObject
    {
        [Header("章节（比如CHAPTER 01.）"), SerializeField]
        private string m_chapter;
        
        [Header("章节名称（比如xxxxx）"), SerializeField]
        private string m_chapterName;
        
        [Header("简介"), SerializeField]
        private string m_text;
        
        [Header("预览"), SerializeField]
        private Sprite m_preview;

        [Header("存档本体"), SerializeField]
        private TextAsset m_saveAsset;
        
        public string Chapter
        {
            get => m_chapter;
            set => m_chapter = value;
        }
        
        public string ChapterName
        {
            get => m_chapterName;
            set => m_chapterName = value;
        }
        
        public string Text
        {
            get => m_text;
            set => m_text = value;
        }

        public Sprite Preview
        {
            get => m_preview;
        }

        public string SaveFile
        {
            get => m_saveAsset.text;
        }
    }
}
