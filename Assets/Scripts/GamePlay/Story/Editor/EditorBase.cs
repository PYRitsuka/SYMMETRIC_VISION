using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Story.Editor
{
    public class EditorBase : MonoBehaviour
    {
        [SerializeField] protected Dropdown condition, controlFlow;

        public virtual string To()
        {
            throw new InvalidOperationException("Why are you trying to using the base class???");
        }
        
        public virtual void From()
        {
            throw new InvalidOperationException("Why are you trying to using the base class???");
        }

        protected void ResetDropdownWithFileNames(Dropdown d, string folder, bool withNone = false)
        {
            var allAssetPaths = AssetDatabase.FindAssets("", new[] { folder }).ToList();
            if (withNone)
            {
                List<Dropdown.OptionData> l = new(){new ("无")};
                var l2 = allAssetPaths.ConvertAll(x => new Dropdown.OptionData(Path.GetFileName(AssetDatabase.GUIDToAssetPath(x))));
                l.AddRange(l2);
                d.options = l;
            }
            else
            {
                var l = allAssetPaths.ConvertAll(x => new Dropdown.OptionData(Path.GetFileName(AssetDatabase.GUIDToAssetPath(x))));
                d.options = l;
            }
        }

        protected string Resolve(string content)
        {
            if (content.Contains(",") || content.Contains("\n") || content.Contains("\""))
            {
                content = content.Replace("\"", "\"\"");
                content = "\"" + content + "\"";
            }
            return content;
        }
    }
}