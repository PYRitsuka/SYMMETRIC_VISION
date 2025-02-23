using System;
using Common;
using UnityEngine.SceneManagement;
using GamePlay.Story.RecordsResolver;
namespace Utils.StoryScriptFunctions
{
    public class BackToTitle : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 1;
        
        protected override void FunctionMain(string[] data)
        {
            BGMResolver.Instance.StopManually();
            SceneManager.UnloadSceneAsync("StoryScene");
            SceneTransit.Instance.TransitTo("TitleScene");
        }
    }
}