using System;
using GamePlay.Story;
using UnityEngine;

namespace Utils.StoryScriptFunctions
{
    internal class SetChapter : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 2;
        
        protected override void FunctionMain(string[] data)
        {
            ScriptResolver.ChapterNumber = data[0].Trim();
            ScriptResolver.ChapterName = data[1].Trim();
            Debug.Log($"Set chapter number to {ScriptResolver.ChapterNumber} and chapter name to {ScriptResolver.ChapterName}");
        }
    }
}