using GamePlay.Story.Record;
using UI.Story;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;

namespace GamePlay.Story.RecordsResolver
{
    public class FilterResolver : MonoBehaviourSingleton<FilterResolver>, IResolvable
    {
        [SerializeField] private RawImage 回忆滤镜;
        [SerializeField] private RawImage 冷色调花屏;
        [SerializeField] private UGUIVideoPlayer 灰色雪花屏;
        
        
        private Filter _currentData;
        private UnityEvent _disableFilterEvent = new();

        public void Resolve(object data)
        {
            _currentData = data as Filter;
            if (_currentData == null)
            {
                Debug.LogError("Filter操作数据读取失败");
                return;
            }
            
            ResolveFilter();
        }

        void ResolveFilter()
        {
            switch (_currentData.FilterName)
            {
                case "无滤镜":
                    _disableFilterEvent.Invoke();
                    _disableFilterEvent = new UnityEvent();
                    break;
                case "回忆滤镜":
                    回忆滤镜.color = Color.white;
                    _disableFilterEvent.AddListener(() =>
                    {
                        回忆滤镜.color = Color.clear;
                    });
                    break;
                case "灰色雪花屏":
                    灰色雪花屏.SetAlpha(1);
                    _disableFilterEvent.AddListener(() =>
                    {
                        灰色雪花屏.SetAlpha(0);
                    });
                    break;
                case "冷色调花屏":
                    冷色调花屏.color = Color.white;
                    _disableFilterEvent.AddListener(() =>
                    {
                        冷色调花屏.color = Color.clear;
                    });
                    break;
                default:
                    break;
            }
        }
    }
}