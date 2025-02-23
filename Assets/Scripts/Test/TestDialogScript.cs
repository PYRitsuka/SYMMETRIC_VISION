using Extensions;
using TMPro;
using UnityEngine;

namespace Test
{
    public class TestDialogScript : MonoBehaviour
    {
        private TMP_Text _thisText;
        void Start()
        {
            _thisText = GetComponent<TMP_Text>();
            string lineHeight = "<line-height=105%><voffset=0.5em>";
            string text = "<nobr>稍有不慎，就会引起<stress>世界线变动</stress>这是一段长文本测试着重点添加是否成功<stress>分段测试这是一段</stress>长文本测试着重点添加是否成功</nobr>";
            text = text.Stress();
            Debug.Log(text);
            _thisText.text = lineHeight+text;
        }
    }
}
