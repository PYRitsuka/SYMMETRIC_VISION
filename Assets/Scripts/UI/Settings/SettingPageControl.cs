using System.Collections.Generic;
using GamePlay.Story;
using GamePlay.Story.RecordsResolver;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class SettingPageControl : MonoBehaviour
    {
        [SerializeField] private List<CustomSlider> controls;
        [SerializeField] private List<float> defaultValues;
        [SerializeField] private List<string> saveNames;
        [SerializeField] private Button resetButton;

        void Start()
        {
            for (var index = 0; index < saveNames.Count; index++)
            {
                var n = saveNames[index];
                float val;
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                controls[index].Set((val = PlayerPrefs.GetFloat(n, -100)) == -100 ? defaultValues[index] : val);
                if (n == "globalVolume")
                {
                    ScriptResolver.GlobalVolume = controls[index].Get();
                    controls[index].OnChanged = delegate (float x)
                    {
                        ScriptResolver.GlobalVolume = x;
                    };
                }
                else if (n == "backgroundMusicVolume")
                {
                    BGMResolver.BackgroundMusicVolume = controls[index].Get();
                    controls[index].OnChanged = delegate (float x)
                    {
                        BGMResolver.BackgroundMusicVolume = x;
                    };
                }
            }
            resetButton.onClick.AddListener(Reset);
        }

        public static void ToogleFullScreen() {
            Screen.fullScreen = !Screen.fullScreen;
        }

        void Reset()
        {
            for (var index = 0; index < saveNames.Count; index++)
            {
                var n = saveNames[index];
                controls[index].Set(defaultValues[index]);
                PlayerPrefs.SetFloat(n, defaultValues[index]);
            }
            Save();
        }

        public void Save()
        {
            for (var index = 0; index < saveNames.Count; index++)
            {
                var val = controls[index].Get();
                PlayerPrefs.SetFloat(saveNames[index], val);
            }
            PlayerPrefs.Save();
        }
    }
}