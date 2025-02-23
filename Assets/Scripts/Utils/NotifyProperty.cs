using System.Runtime.CompilerServices;
using UnityEngine;

namespace Utils
{
    public sealed class NotifyProperty<T>
    {
        private T _value;

        public NotifyProperty(T value = default)
        {
            _value = value;
        }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(value);
            }
        }
        
        public delegate void PropertyChangedEventHandler(T value);

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged(T value)
        {
            PropertyChanged?.Invoke(value);
        }
    }
}