using DG.Tweening;
using Save;
using UnityEngine;
using UnityEngine.UI;

namespace UI.StoryLine
{
    public class StoryArrowUIController : MonoBehaviour
    {
        [SerializeField] private int id;

        private Image _image;
        
        void Awake()
        {
            _image = GetComponent<Image>();
        }
        
        void Start()
        { 
            NoticeUpdate();
        }

        private void NoticeUpdate()
        {
            var unlocked = GlobalSaveManager.HasIndexedSystemFlag("StoryArrow",id);
            _image.DOFade(unlocked ? 1 : 0, .01f);
        }
    }
}