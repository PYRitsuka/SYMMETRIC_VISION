using System;
using GamePlay.Story;

namespace Utils.StoryScriptFunctions
{
    public class JumpToLine : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 1;
        
        protected override void FunctionMain(string[] data)
        {
            if (!int.TryParse(data[0], out var line))
            {
                LogInvalidArgument(data[0]);
            }
            ScriptResolver.Instance.JumpToLine(line, true);
        }
    }
}