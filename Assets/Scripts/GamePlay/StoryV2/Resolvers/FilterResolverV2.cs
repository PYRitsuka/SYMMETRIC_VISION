
using UnityEngine;
using UnityEngine.UI;


namespace GamePlay.StoryV2.RecordsResolver
{
    public class FilterResolverV2:MonoBehaviour {

        public RawImage snow;
        public RawImage memory;
        public RawImage coldColor;
        

        RawImage GetFilter(string name) {
            switch(name) {
                case "flake":
                    return snow;
                case "memory":
                    return memory;
                case "coldColor":
                    return coldColor;
                default:
                    return null;
            }
        }

        public void Clear(){
            SetEnabled("flake",false);
            SetEnabled("memory",false);
            SetEnabled("coldColor",false);
        }

        public void SetEnabled(string filter,bool state) {
            RawImage img = GetFilter(filter);
            if (img != null) {
                Debug.LogError($"{filter}: Filter Not Recognized");
                return;
            }
            var alpha = state ? 1: 0;
            img.color = new Color(1,1,1,alpha);
            if (state) {
                img.gameObject.SetActive(true);
            } else {
                img.gameObject.SetActive(false);
            }
        }

    }
}