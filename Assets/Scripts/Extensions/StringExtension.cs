using System;

namespace Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 加重一段文本(TMP)中以stress属性标记的所有子串。
        /// </summary>
        /// <returns>返回转换完的TMP字符串</returns>
        public static string Stress(this string text)
        {
            int i = text.IndexOf("<stress>", StringComparison.Ordinal);
            if (i == -1)
            {
                return text;
            }
            int j = text.IndexOf("</stress>",i, StringComparison.Ordinal);
            // 去标签后文本
            string stressText = text.Substring(i + 8 , j - i -8);
            string stressTextNew = "";
            // 添加着重符
            for(int k = 0; k < stressText.Length; k++)
            {
                if (k == 0)
                {
                    stressTextNew += stressText[k];
                }
                else if (k == stressText.Length - 1)
                {
                    stressTextNew += "<space=-0.9em><voffset=-0.26em><b><size=40>·</size></b></voffset><voffset=0.5em><space=0.1em>"+ stressText[k] + "<space=-0.9em><voffset=-0.26em><b><size=40>·</size></b></voffset><voffset=0.5em><space=0.1em>";
                }
                else
                {
                    stressTextNew += "<space=-0.9em><voffset=-0.26em><b><size=40>·</size></b></voffset><voffset=0.5em><space=0.1em>"+stressText[k];
                }
            }
            // 文本去除标签
            text = text.Replace("<stress>"+stressText+"</stress>",stressTextNew);
            return Stress(text);
        }
    }
}