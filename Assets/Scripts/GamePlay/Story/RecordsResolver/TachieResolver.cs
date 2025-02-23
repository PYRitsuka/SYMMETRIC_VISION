using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using GamePlay.Story.Record;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace GamePlay.Story.RecordsResolver
{
    public class TachieResolver : MonoBehaviourSingleton<TachieResolver>, IResolvable
    {
        [SerializeField] private RawImage archetype;
        
        private Tachie _currentData;
        private RawImage _selectedTachie;
        private string _selectedTachieName;
        private readonly Dictionary<string, RawImage> _tachies = new ();
        private static readonly int TransitTex = Shader.PropertyToID("_TransitTex");
        private static readonly int Progress = Shader.PropertyToID("_Progress");
        private static readonly int Alpha = Shader.PropertyToID("_Alpha");
        

        public static List<ResourceRecord> getResources(object data)
        {

            var resources = new List<ResourceRecord> ();
            var currData = data as Tachie;
            if (currData == null)
            {
                Debug.LogError("Error Preloading Background");
                return resources;
            }
            int idx = 0;
            if (currData.Operation == "创建图片") {
                idx  = 0;
            } else if (currData.Operation == "切换图片")  {
                idx  = 1;
            }
            else {
                return resources;
            }
            var list = currData.Pattern.SplitSemicolon();
            if (list.Count < 2)
            {
                Debug.LogError("Invalid create background command: " + currData.Pattern);
                return resources;
            }
            var backgroundPicture = list[idx];
            resources.Add( new ResourceRecord("Texture",$"立绘/{backgroundPicture}"));
            return resources;
            
        }

        public void Resolve(object data)
        {
            _currentData = data as Tachie;
            if (_currentData == null)
            {
                Debug.LogError("立绘操作数据读取失败");
                return;
            }
            
            switch (_currentData.Operation)
            {
                case "创建图片":
                    CreateTachie(_currentData.Pattern);
                    break;
                case "切换图片":
                    ChangeTachie(_currentData.Pattern);
                    break;
                case "选中图片":
                    _selectedTachieName = _currentData.Pattern.SplitSemicolon().FirstOrDefault();
                    System.Diagnostics.Debug.Assert(_selectedTachieName != null, nameof(_selectedTachieName) + " != null");
                    _selectedTachie = _tachies[_selectedTachieName];
                    break;
                case "删除图片":
                    _tachies.Remove(_selectedTachieName);
                    Destroy(_selectedTachie.gameObject);
                    break;
                default:
                    Debug.LogError("Unknown tachie command: " + _currentData.Operation);
                    break;
            }
            
            ChangeColor();
            TransitScale();
            TransitMove();
            TransitAlpha();
            Animate();
        }

        void Animate()
        {
            if (!string.IsNullOrEmpty(_currentData.Animation))
            {
                switch (_currentData.Animation)
                {
                    case "轻微抖动":
                        _selectedTachie.rectTransform.DOShakeAnchorPos(.5f, 10f, 20, 90f, false, false);
                        ScriptResolver.WaitTime.Value = .5f;
                        break;
                    case "剧烈抖动":
                        _selectedTachie.rectTransform.DOShakeAnchorPos(.5f, 20f, 20, 90f, false, false);
                        ScriptResolver.WaitTime.Value = .5f;
                        break;
                }
            }
        }
        
        void TransitScale()
        {
            if (!string.IsNullOrEmpty(_currentData.ScaleTransition))
            {
                var list = _currentData.ScaleTransition.SplitSemicolon();
                if (list.Count < 3)
                {
                    Debug.LogError("Invalid scale tachie command: " + _currentData.ScaleTransition);
                    return;
                }

                var duration = list[2].ToFloat();
                if (duration == 0)
                {
                    _selectedTachie.rectTransform.localScale = Vector3.one * list[1].ToFloat();
                }
                else
                {
                    _selectedTachie.rectTransform.localScale = Vector3.one * list[0].ToFloat();
                    _selectedTachie.rectTransform.DOScale(Vector3.one * list[1].ToFloat(), duration);
                }
                
                ScriptResolver.WaitTime.Value = duration;
            }
        }
        
        void TransitMove()
        {
            if (!string.IsNullOrEmpty(_currentData.MoveTransition))
            {
                var list = _currentData.MoveTransition.SplitSemicolon();
                if (list.Count < 5)
                {
                    Debug.LogError("Invalid move tachie command: " + _currentData.MoveTransition);
                    return;
                }

                var duration = list[4].ToFloat();
                if (duration == 0)
                {
                    _selectedTachie.transform.localPosition = new Vector3(list[2].ToInt(), list[3].ToInt(), 1);
                }
                else
                {
                    _selectedTachie.transform.localPosition = new Vector3(list[0].ToInt(), list[1].ToInt(), 1);
                    _selectedTachie.transform.DOLocalMove(new Vector3(list[2].ToInt(), list[3].ToInt(), 1), duration);
                }
                
                ScriptResolver.WaitTime.Value = duration;
            }
        }
        
        void TransitAlpha()
        {
            if (string.IsNullOrEmpty(_currentData.AlphaTransition))
            {
                return;
            }
            var img = _selectedTachie;
            var list = _currentData.AlphaTransition.SplitSemicolon();
            if (list.Count < 3)
            {
                Debug.LogError("Invalid alpha tachie command: " + _currentData.AlphaTransition);
                return;
            }
            
            var duration = list[2].ToFloat();
            if (duration == 0)
            {
                _selectedTachie.material.SetFloat(Alpha, list[1].ToFloat());
            }
            else
            {
                _selectedTachie.material.SetFloat(Alpha, list[0].ToFloat());
                _selectedTachie.material.DOFloat(list[1].ToFloat(), Alpha, duration);
            }

            ScriptResolver.WaitTime.Value = duration;
        }

        //TODO: Should be modified without try catch
        void ChangeColor()
        {
            if (string.IsNullOrEmpty(_currentData.Color))
            {
                return;
            }
            
            var l = _currentData.Color.SplitSemicolon();
            try
            {
                var r = l[0].ToInt() / 255f;
                var g = l[1].ToInt() / 255f;
                var b = l[2].ToInt() / 255f;
                _selectedTachie.color = new Color(r, g, b, _selectedTachie.color.a);
            }
            catch (Exception e)
            {
                // ignored
            }
        }
        
        void CreateTachie(string pat)
        {
            var list = pat.SplitSemicolon();
            if (list.Count < 2)
            {
                Debug.LogError("Invalid create tachie command: " + pat);
                return;
            }

            var backgroundPicture = list[0];//.WithoutExtension();
            var backgroundName = list[1];
            if (!_tachies.ContainsKey(backgroundName))
            {
                var img = Instantiate(archetype, transform);
                img.texture = StoryUtils.LoadResource<Texture>($"立绘/{backgroundPicture}");
                //img.texture = StoryUtils.LoadAddressable<Texture>($"立绘/{backgroundPicture}");
                img.material = new Material(Shader.Find("Unlit/AlphaTransit"));
                img.gameObject.SetActive(true);
                img.SetNativeSize();
                _selectedTachie = img;
                _selectedTachieName = backgroundName;
                _tachies.Add(backgroundName, img);
            }
        }
        
        async void ChangeTachie(string pat)
        {
            var list = pat.SplitSemicolon();
            if (list.Count < 3)
            {
                Debug.LogError("Invalid change background command: " + pat);
                return;
            }

            var backgroundPicture = list[1];//.WithoutExtension();
            var backgroundName = list[0]; //todo: fix it, change 和 create 顺序是反过来的也是天才
            if (!_tachies.ContainsKey(backgroundName))
            {
                Debug.LogError("Invalid picture indicator: " + backgroundName);
                return;
            }

            var img = _tachies[backgroundName];

            var tex = StoryUtils.LoadResource<Texture>($"立绘/{backgroundPicture}");
            //var tex = StoryUtils.LoadAddressable<Texture>($"立绘/{backgroundPicture}");
            var duration = list[2].ToFloat();
            ScriptResolver.WaitTime.Value = duration;
            
            img.material.SetTexture(TransitTex, tex);
            await img.material.DOFloat(1, Progress, duration).AsyncWaitForCompletion();
            img.texture = tex;
            img.material.SetFloat(Progress, 0);
        }
    }
}