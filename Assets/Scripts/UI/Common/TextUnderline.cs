using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
    /// <summary>
    /// 字符串(Legacy Text)加下划线
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class TextUnderline : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Image underlinePrefab;
        private Text text;

        private void Start()
        {
            text = GetComponent<Text>();
            DrawUnderline(10, 14);
        }

        private Vector3 GetPosAtText(int charIndex, bool isLeft)
        {
            string textStr = text.text;
            Vector3 charPos = Vector3.zero;
            if (charIndex <= textStr.Length && charIndex > 0)
            {
                TextGenerator textGen = new TextGenerator();
                Vector2 extents = text.gameObject.GetComponent<RectTransform>().rect.size;
                textGen.Populate(textStr, text.GetGenerationSettings(extents));

                int newLine = textStr.Split('\n').Length - 1;
                int whiteSpace = textStr.Split(' ').Length - 1;
                int indexOfTextQuad = (charIndex * 4) - (newLine * 4) - (whiteSpace * 4) - 4;
                if (indexOfTextQuad < textGen.vertexCount)
                {
                    if (isLeft) 
                        charPos = textGen.verts[indexOfTextQuad + 3].position;
                    else
                        charPos = textGen.verts[indexOfTextQuad + 2].position;
                }
            }

            charPos /= canvas.scaleFactor;
            charPos = Camera.main.WorldToScreenPoint(text.transform.TransformPoint(charPos));
            charPos = new Vector3(charPos.x / Screen.width * 1920f - 960f, charPos.y / Screen.height * 1080f - 540f, charPos.z);
            return charPos;
        }
    
        public void DrawUnderline(int fromIndex, int toIndex)
        {
            var line = Instantiate(underlinePrefab, canvas.transform);
            var fromPos = GetPosAtText(fromIndex, true);
            line.rectTransform.anchoredPosition = fromPos - new Vector3(0, 3f);
            var toPos = GetPosAtText(toIndex, false);
            line.rectTransform.sizeDelta = new Vector3(toPos.x - fromPos.x, 3f);
        }
    }
}