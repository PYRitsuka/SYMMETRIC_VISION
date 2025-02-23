using System;
using DG.Tweening;
using GamePlay.Story;
using UnityEngine;

namespace Common
{
    public class SceneBGMPlayer : MonoBehaviour
    {
        [SerializeField] private float fadeInTime;
        [SerializeField] private Ease fadeInEase;
        [SerializeField] private float fadeOutTime;
        [SerializeField] private Ease fadeOutEase;
        [SerializeField] private float minVolume;
        [SerializeField] private float maxVolume;
        [SerializeField] private AudioClip clip;

        private float _volume = 0f;
        private AudioSource _audioSource;

        private void Start()
        {
            Play();
            SceneTransit.RegisterSceneTransitEvent(Stop);
        }

        private void Play()
        {
            _audioSource = DontDestroyOnLoadRoot.GetAudioSource();
            _audioSource.clip = clip;
            _audioSource.Play();
            DOTween.To(x => _volume = x, minVolume, maxVolume, fadeInTime).SetEase(fadeInEase);
        }

        private void Update()
        {
            _audioSource.volume = _volume * PlayerPrefs.GetFloat("globalVolume", 1) * PlayerPrefs.GetFloat("backgroundMusicVolume", 1);
        }

        private void Stop()
        {
            SceneTransit.UnregisterSceneTransitEvent(Stop);
            DOTween.To(x => _audioSource.volume = x, maxVolume, minVolume, fadeOutTime).SetEase(fadeOutEase)
                .OnComplete(_audioSource.Stop);
        }
    }
}