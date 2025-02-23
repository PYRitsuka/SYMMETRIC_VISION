using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;
using  GamePlay.Story.Backlog;
using GamePlay.StoryV2;

namespace GamePlay.Story.UI
{
    public class TipTrigger : MonoBehaviour, IPointerClickHandler
    {
        private TMP_Text _text;
        public bool hasClick;
        

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            var index = TMP_TextUtilities.FindIntersectingLink(_text, eventData.position, Camera.main);
            Debug.Log($"BackLog Pointer Click! {index}");
            if (index == -1)
            {
                return;
            }
            var linkID = _text.textInfo.linkInfo[index].GetLinkID();
            Debug.Log($"BackLog Pointer Click! link id {linkID}");
            var windowTexture = StoryUtils.LoadResource<Texture>($"Tips/TipsWindow_{linkID}.png");
            var tipTexture = StoryUtils.LoadResource<Texture>($"Tips/Tips_{linkID}.png");
            //ScriptResolver.IsMouseOverTips = false;
            BacklogManager.Instance.hasClick = true; // just block one propagation
            Debug.Log($"BackLog Pointer Click! Tip Call");
            ScriptResolverV2.Instance.hasClick = true;
            TipPresenter.Instance.Present(tipTexture, windowTexture);
        }
        //get rid of useless checks
        // public void OnPointerMove(PointerEventData eventData)
        // {
        //     var index = TMP_TextUtilities.FindIntersectingLink(_text, eventData.position, null);
        //     // ScriptResolver.IsMouseOverTips = index != -1;
        // }
        
        // public void OnPointerExit(PointerEventData eventData)
        // {
        //     ScriptResolver.IsMouseOverTips = false;
        // }
    }
}