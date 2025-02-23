using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace GamePlay.Story.Editor
{
    public class TextEditor : EditorBase
    {
        [SerializeField] private Dropdown frame;
        [SerializeField] private InputField alpha;
        [SerializeField] private InputField charName;
        [SerializeField] private InputField fontSize;
        [SerializeField] private InputField speed;
        [SerializeField] private Dropdown icon;
        [SerializeField] private TMP_InputField content;

        private void Start()
        {
            ResetDropdownWithFileNames(icon, "Assets/Resources/文本框", true);
        }

        private void Update()
        {
            Debug.Log(To());
        }

        public override string To()
        {
            var list = new List<string>
            {
                "文本", condition.captionText.text, controlFlow.captionText.text,
                frame.captionText.text, alpha.text, charName.text, content.text, fontSize.text, speed.text,
                icon.captionText.text
            };
            for (var index = 0; index < list.Count; index++)
            {
                var i = list[index];
                list[index] = Resolve(i);
            }

            return string.Join(",", list);
        }
    }
}