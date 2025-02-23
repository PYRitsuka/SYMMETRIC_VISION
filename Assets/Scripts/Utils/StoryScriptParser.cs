using System;
using System.Collections.Generic;
using System.Linq;
using Save;
using UnityEngine;
using Utils.StoryScriptFunctions;

namespace Utils
{
    [Obsolete]
    public class StoryScriptParser
    {
        /// <summary>
        /// 函数名称对应的StoryScriptFunction
        /// </summary>
        private readonly Dictionary<string, StoryScriptFunction> _functionMap;

        public StoryScriptParser()
        {
            _functionMap = new Dictionary<string, StoryScriptFunction>
            {
                ["wait"] = new Wait(), //最好起同一个名字，但是wait小写emm我也不到为啥（）
                ["SetUIMode"] = new SetUIMode(), //像这样
                ["CanSkip"] = new CanSkip(),
                ["JumpToScript"] = new JumpToScript(),
                ["SetChapter"] = new SetChapter(),
                ["JumpToLine"] = new JumpToLine(),
                ["VisionTrigger"] = new VisionTrigger(),
                ["Trigger"] = new Trigger(),
                ["BackToTitle"] = new BackToTitle(),
                ["VisionChange"] = new VisionChange(),
                ["VisionCwithBGM"] = new VisionChange(false),
                ["StoryArrow"] = new StoryArrow(),
                ["StoryBlock"] = new StoryBlock(),
            };
        }
        [Obsolete]
        public void ParseScript(string script, string condition)
        {
            
            // if (condition.Contains("Trigger"))
            // {
            //     var variableName = condition.Split(new[] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries)[1];
            //     if (GlobalSaveManager.CurrentSave.BoolProperties.TryGetValue(variableName, out var val))
            //     {
            //         if (val == (condition[0] == '!')) return;
            //     }
            //     else if (condition[0] != '!') return;
            // }
            
            string[] lines = script.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //分割行数，可以进行多行处理

            foreach (string line in lines)
            {
                string[] parts = line.Split('(', ')');
                //用()分割 如 wait(3); 会分为 wait 3 ;
                if (parts.Length >= 2) //本来是3但是剧本有时不写分号我就改成2了（
                {
                    string functionName = parts[0];
                    if (_functionMap.ContainsKey(functionName))
                    {
                        _functionMap[functionName].Do(parts[1].Split(',').Select(x => x.Trim()).ToArray());
                    }
                    else
                    {
                        Debug.LogError($"Unknown function '{functionName}'");
                    }
                }
                else
                {
                    Debug.LogError($"Invalid syntax: {line}");
                }
            }
        }
        public static string LoadPotentialJumpDestination(string script, string condition)
        {
            // This need to redo
            // One line only now
            var line = script;
            string[] parts = line.Split('(', ')');
                //用()分割 如 wait(3); 会分为 wait 3 ;
                // TODO: change to Regrex
                if (parts.Length >= 2) //本来是3但是剧本有时不写分号我就改成2了（
                {
                    string functionName = parts[0];
                    var data = parts[1].Split(',').Select(x => x.Trim()).ToArray();
                    // int idx = 0;
                    // foreach (var s in data) {
                    //     Debug.Log($"Data ({functionName}) {idx}:: {s}");
                    //     idx++;
                    // }
                    if (functionName == "JumpToScript") {
                        return $"脚本/{data[0]}";
                    } else if (functionName == "VisionChange" || functionName == "VisionCwithBGM" ) {
                        return $"脚本/{data[1]}";
                    } else if (functionName == "VisionTrigger" && data[0] == "true") {
                        return $"脚本/{data[2]}";
                    } else {
                        return null;
                    }
                }
                else
                {
                    Debug.LogError($"Invalid syntax: {line}");
                }
                return null;
        }
        
    }

    /// <summary>
    /// 所有StoryScriptFunction的爹，儿子放在Scripts/Utils/StoryScriptFunctions下
    /// </summary>
    public abstract class StoryScriptFunction
    {
        /// <summary>
        /// 设定参数个数
        /// </summary>
        protected abstract Func<int, bool> CheckArgumentCountFunction { get; }

        private bool CheckArgumentCount(string[] data)
        {
            if (CheckArgumentCountFunction(data.Length))
            {
                return true;
            }
            Debug.LogError($"Invalid argument count (arguments: {string.Join(", ", data)}) for function {GetType().Name}");
            return false;
        }

        /// <summary>
        /// 报错某个参数不合法
        /// </summary>
        /// <param name="arg">需要报错的参数</param>
        protected void LogInvalidArgument(string arg)
        {
            Debug.LogError($"Invalid argument {arg} for function {GetType().Name}");
        }

        protected abstract void FunctionMain(string[] data);
        
        public void Do(string[] data)
        {
            if (!CheckArgumentCount(data))
            {
                return;
            }
            FunctionMain(data);
        }
    }
}