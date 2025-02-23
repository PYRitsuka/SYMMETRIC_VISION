using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.StoryV2.RecordsResolver
{
    public class ScriptResolverV2ClickBlocker : MonoBehaviour, IPointerClickHandler,IPointerUpHandler
    {
        public string debug_name;
        // This method is called when the user clicks on the ScrollView
        public void OnPointerClick(PointerEventData eventData)
        {
            
            Debug.Log($"Blocked MouseUp {debug_name}!");
            BlockClick();
        }

        public void OnPointerUp(PointerEventData eventData) {
            Debug.Log($"Blocked MouseUp {debug_name}!");
            BlockClick();
        }

        public static void BlockClick() {
            ScriptResolverV2.Instance.hasClick = true;
        }


    }


}