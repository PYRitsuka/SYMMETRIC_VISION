using System;

namespace Utils
{
    public class WaitTime
    {
        private float _value;

        public float Value
        {
            get => _value;
            set => _value = Math.Max(_value, value);
        }

        public WaitTime(float value)
        {
            _value = value;
        }

        public void Reset()
        {
            _value = 0f;
        }
    }
}