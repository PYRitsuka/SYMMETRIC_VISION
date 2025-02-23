using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using DG.Tweening;
using GamePlay.Story.Record;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using UnityEngine.Video;
using System.Runtime.InteropServices;
using Constants;
namespace GamePlay.StoryV2.RecordsResolver
{
    public class AudioResolverV2 : MonoBehaviourSingleton<AudioResolverV2>
    {
        public AudioSource _audioSource;
        private string _currentClip;

        private float _volume;

        private float _volume_factor = 1;


        Tween loopHandler;
        Tween volumeHandler;
        public static float BackgroundMusicVolume { get; set; } = 1;
        public HashSet<AudioSource> loopingSE;
        public HashSet<AudioSource> currentSE;

        public string GetPath(string prefix,string file) {
            if (file.StartsWith("//")) {
                return file.Substring(2);
            } else {
                return $"{prefix}{file}";
            }
        }

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            BackgroundMusicVolume = PlayerPrefs.GetFloat("backgroundMusicVolume", 1);
            loopingSE = new();
            currentSE = new();
        }

        void Awake()
        {
            var objs = GameObject.FindObjectsOfType<AudioResolverV2>();

            if (objs.Length > 1 )
            {
                DestroyImmediate(this.gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            Instance = this as AudioResolverV2;
            // ScriptResolverV2.Instance.audioResolver = this;
        }
        void UpdateVolume() {
            _audioSource.volume = _volume *  BackgroundMusicVolume * _volume_factor;
        }
        public void SetVolMul(float v) {
            _volume_factor = v;
            UpdateVolume();
        }
        
        void SetVolume(float v)
        {
            _volume = v;
            UpdateVolume();
        }
        
        public void PlayBGM(string clip_name,float volume,bool loop,float begin,float end) {
            string address = GetPath("BGM/",clip_name);
            if (_currentClip != address)
            {
                var clip = StoryUtils.LoadResource<AudioClip>(address);
                _audioSource.clip = clip;
                _audioSource.Play();
                _currentClip = address;
            }
            if (loopHandler != null) {
                loopHandler.Kill();
                loopHandler = null;
            }
            if (volumeHandler != null) {
                volumeHandler.Kill(true);
                volumeHandler = null;
            }
            SetVolume(volume);
            _audioSource.loop = loop;
            if (loop && (end > 0) && (begin < end) && (end < _audioSource.clip.length)) {
                _audioSource.time = begin;
                var delta_t = end - begin;
                loopHandler = DOVirtual.DelayedCall(delta_t,()=>{
                    _audioSource.time = begin;
                }
                );
                loopHandler.SetAutoKill(false);
                loopHandler.OnComplete(
                    ()=>{
                        loopHandler.Restart();
                    }
                );
            } 
        }

        public void VolumeChange(float begin, float end, float duration) {
            if (duration == 0){
                SetVolume(end);
            }
            SetVolume(begin);
            volumeHandler =  DOVirtual.Float(begin,end,duration,(v)=>{
                SetVolume(v);
            });
            volumeHandler.OnComplete(()=>{SetVolume(end);volumeHandler = null;});
            volumeHandler.OnKill(()=>volumeHandler.Complete(true));
        }

        public void PlayBlank() {
            PlayBGM("blank.mp3",1.0f,false,0,0);
        }

        public void StopManually()
        {
            _currentClip = null;
            _audioSource.Stop();
            _audioSource.clip = null;
        }
        public void PlayClipAtPoint(AudioClip clip, Vector3 position, float volume, bool loop)
        {
            GameObject gameObject = new GameObject("One shot audio");
            gameObject.transform.position = position;
            AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
            audioSource.clip = clip;
            audioSource.spatialBlend = 1f;
            audioSource.volume = volume;
            currentSE.Add(audioSource);
            audioSource.Play();
            if (loop) {
                audioSource.loop = true;
                loopingSE.Add(audioSource);
            } else {
                UnityEngine.Object.Destroy(gameObject, clip.length * ((Time.timeScale < 0.01f) ? 0.01f : Time.timeScale));
            }
            
        }


        public void PlaySE(string clipName,float volume,bool loop)
        {
            var clip_name = GetPath("SE/",clipName);
            var clip = StoryUtils.LoadResource<AudioClip>(clip_name);
            PlayClipAtPoint(clip,Camera.main.transform.position,
            volume  * PlayerPrefs.GetFloat("sfxVolume", SettingsConstants.SfxVolume),loop
            );
        }

        public void StopSE()
        {
            //foreach (AudioSource audioSource in loopingSE)
            //{
            //    Debug.Log("当前音效");
            //    audioSource.Stop();
            //    Destroy(audioSource.gameObject);
            //}
            //loopingSE.Clear();
            foreach (AudioSource audioSource in currentSE)
            {
                Debug.Log("当前音效" + audioSource);
                if (audioSource != null)
                {
                    audioSource.Stop();
                    Destroy(audioSource.gameObject);
                }
                continue;
            }
            currentSE.Clear();
        }
    }


}