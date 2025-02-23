using System;
using System.Threading.Tasks;
using Baracuda.Threading;
using DG.Tweening;
using GamePlay.Story.Record;
using GamePlay.Story.UI;
using UnityEngine;
using Utils;

namespace GamePlay.Story.RecordsResolver
{
    public class SpecialResolver : MonoBehaviourSingleton<SpecialResolver>, IResolvable
    {
        [SerializeField] private CanvasGroup canvasGroup;
        private Special _currentData;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public async void Resolve(object data)
        {
            _currentData = data as Special;
            
            if (_currentData == null)
            {
                Debug.LogError("特殊操作数据读取失败");
                return;
            }

            canvasGroup.blocksRaycasts = true;

            switch (_currentData.Function)
            {
                case "选项":
                    if (!ScriptResolver.IsJumping)
                    {
                        await SelectAsync();
                    }
                    else
                    {
                        // ReSharper disable once MethodHasAsyncOverload
                        Select();
                    }
                    break;
                default:
                    Debug.LogError("Unknown function " + _currentData.Function);
                    break;
            }

            canvasGroup.blocksRaycasts = false;
        }

        private async Task SelectAsync()
        {
            // var res = await SelectionController.Instance.StartSelectAsync(_currentData.Content);
            // ScriptResolver.Instance.JumpToLine(res, false);
        }
        
        private void Select()
        {
            var res = SelectionController.Instance.StartSelect(_currentData.Content);
            ScriptResolver.Instance.JumpToLine(res, false);
        }
    }
}