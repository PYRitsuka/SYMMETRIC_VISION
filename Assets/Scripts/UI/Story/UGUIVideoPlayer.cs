using System;
using System.Threading.Tasks;
using Baracuda.Threading;
using Constants;
using CsvHelper.Configuration.Attributes;
using GamePlay.Story;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

namespace UI.Story
{
    public class UGUIVideoPlayer : MonoBehaviour
    {
        [SerializeField] private RawImage image;
        [SerializeField] private VideoPlayer player;
        [SerializeField] private Texture blank;

        public double? Length => player.clip.length;

        void Start()
        {
            image.texture = blank;
            image.color = Color.clear;
        }

        void Update()
        {
            if (player.texture == null)
            {
                return;
            }
            image.texture = player.texture;
        }

        void OnDisable()
        {
            image.color = Color.clear;
        }

        public void SetLoop(bool isLoop)
        {
            player.isLooping = isLoop;
        }

        public void PlayVideo(VideoClip clip = null)
        {
            if (clip != null)
            {
                player.clip = clip;
            }
            player.Prepare();
            player.SetDirectAudioVolume(0,
                ScriptResolver.GlobalVolume * PlayerPrefs.GetFloat("videoVolume", SettingsConstants.VideoVolume));
            player.Play();
            player.prepareCompleted += delegate { image.color = Color.white; };
        }

        public void DestroyVideo()  
        {
            player.Stop();
            Destroy(gameObject);
        }

        public void Reset()
        {
            player.Stop();
            image.texture = blank;
            image.color = Color.clear;
        }

        public void AddStopCallbackAtTime(float time, out float duration, Action callback = null)
        {
            duration = time - (float)player.time;//player.frame / player.frameRate;
            AddStopCallbackAtTimeAsync(time, duration, callback);
        }

        private async void AddStopCallbackAtTimeAsync(float time, float duration, Action callback)
        {
            Debug.Log("duration = " + duration);
            //await Task.WhenAny(Task.Delay((int)(1000 * duration), ScriptResolver.CancellationTokenSource.Token));
            await Task.Run(delegate
            {
                double elapsed = 0;
                while (true)
                {
                    Dispatcher.InvokeAsync(delegate
                    {
                        elapsed = player.time;
                    }, ScriptResolver.CancellationTokenSource.Token);
                    if (ScriptResolver.CancellationTokenSource.IsCancellationRequested)
                    {
                        return;
                    }
                    if (elapsed >= time)
                    {
                        return;
                    }
                }
            });
            callback?.Invoke();
            if (player == null)
            {
                return;
            }
            player.time = time;
            player.Pause();
        }

        private void Pause(VideoPlayer p)
        {
            player.Pause();
            player.seekCompleted -= Pause;
        }

        public void Continue()
        {
            player.Play();
        }

        public void SetAlpha(float alpha)
        {
            image.color = new Color(1, 1, 1, alpha);
        }

        public void JumpToFrame(long frame)
        {
            if (frame < 0 || frame > (long) player.frameCount)
            {
                return;
            }
            player.frame = frame;
        }
    }
}
