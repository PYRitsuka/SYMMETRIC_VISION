using Constants;
using GamePlay.Story.Record;
using UnityEngine;
using Utils;
using System.Collections.Generic;

namespace GamePlay.Story.RecordsResolver
{
    public class SEResolver : MonoBehaviourSingleton<SEResolver>, IResolvable
    {
        private SE _currentData;

        
        public static List<ResourceRecord> getResources(object data)
        {

            var resources = new List<ResourceRecord> ();
            var currData = data  as SE;
            if (currData == null)
            {
                Debug.LogError("Error Preloading SE");
                return resources;
            }
            var SEName = currData.SEName;
            resources.Add( new ResourceRecord("AudioClip",$"SE/{SEName}"));
            
            return resources;
            
        }

        public void Resolve(object data)
        {
            _currentData = data as SE;
            if (_currentData == null)
            {
                Debug.LogError("SE操作数据读取失败");
                return;
            }
            
            PlayClip(_currentData.SEName);
        }

        void PlayClip(string clipName)
        {
            var clip = StoryUtils.LoadResource<AudioClip>($"SE/{clipName}");
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position,
                _currentData.Volume / 100f * ScriptResolver.GlobalVolume *
                PlayerPrefs.GetFloat("sfxVolume", SettingsConstants.SfxVolume));
        }
    }
}