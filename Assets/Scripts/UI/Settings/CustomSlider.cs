using System;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class CustomSlider : MonoBehaviour
    {
        [SerializeField] private Image fillImage;
        private Slider _slider;

        public Action<float> OnChanged { get; set; }

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            fillImage.fillAmount = LerpTo01();
            _slider.onValueChanged.AddListener(x =>
            {
                OnChanged?.Invoke(x);
                fillImage.fillAmount = LerpTo01();
            });
        }

        private float LerpTo01()
        {
            return (_slider.value - _slider.minValue) / (_slider.maxValue - _slider.minValue);
        }

        public void Set(float val)
        {
            _slider.value = val;
            fillImage.fillAmount = LerpTo01();
        }

        public float Get()
        {
            return _slider.value;
        }
    }
}