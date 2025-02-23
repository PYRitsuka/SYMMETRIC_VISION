using GamePlay.Story.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Story.Backlog
{
    public class Log : MonoBehaviour
    {
        [SerializeField] private TMP_Text speakerText;
        [SerializeField] private TMP_Text contentText;

        public void SetContent(string speaker, string content)
        {
            ResetColor();
            speakerText.text = speaker;
            contentText.text = content;
        }

        public void ResetColor()
        {
            var ui = UIModeController.Instance.GetCurrentUI();
            GetComponent<Image>().sprite = ui.GetLogBackground();
            speakerText.color = ui.GetMainColor();
        }
    }
}