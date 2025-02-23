using System;
using System.IO;
using System.Threading.Tasks;
using Constants;
using DG.Tweening;
using GamePlay.Story.Record;
using UnityEngine;
using Utils;
using System.Collections.Generic;
namespace GamePlay.Story.RecordsResolver
{
    public class BGMResolver : MonoBehaviourSingleton<BGMResolver>, IResolvable
    {
        private BGM _currentData;
        private AudioSource _audioSource;
        private AudioClip _currentClip;

        private float _volume = 0;
        
        public static float BackgroundMusicVolume { get; set; } = 1;


        public static List<ResourceRecord> getResources(object data)
        {

            var resources = new List<ResourceRecord> ();
            var currData = data as BGM;
            if (currData == null)
            {
                Debug.LogError("Error Preloading Music");
                return resources;
            }
            resources.Add( new ResourceRecord("AudioClip", $"BGM/{currData.MusicName}"));
            return resources;
            
        }
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            BackgroundMusicVolume = PlayerPrefs.GetFloat("backgroundMusicVolume", 1);
        }

        void Awake () 
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("MusicHandle");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
                return;
            }
        
            DontDestroyOnLoad (gameObject);
            Instance = this as BGMResolver;
        }


        void Update()
        {
            _audioSource.volume = _volume * ScriptResolver.GlobalVolume * BackgroundMusicVolume;
        }
        
        public void Resolve(object data)
        {
            _currentData = data as BGM;

            if (_currentData == null)
            {
                Debug.LogError("BGM操作数据读取失败");
                return;
            }
            var clip = StoryUtils.LoadResource<AudioClip>(
                $"BGM/{_currentData.MusicName}");
                
            PlayClip(clip, _currentData.VolumeTransition);
        }

        void PlayClip(AudioClip clip, string transition)
        {
            if (_currentClip != clip)
            {
                _audioSource.clip = clip;
                _audioSource.Play();
            }
            _currentClip = clip;
            _audioSource.loop = _currentData.IsLoop;
            var list = transition.SplitSemicolon();
            
            var l1 = list[0].ToFloat() / 100f;
            var l2 = list[1].ToFloat() / 100f;

            _audioSource.volume = l1;
            ScriptResolver.WaitTime.Value = list[2].ToFloat();
            DOTween.To(() => _audioSource.volume, (x) => _volume = x, l2,
                list[2].ToFloat());
        }

        public void StopManually()
        {
            _currentClip = null;
            if (_audioSource == null)
            {
                return;
            }
            _audioSource.Stop();
            _audioSource.volume = 0;
            _audioSource.clip = null;
        }
    }
}
