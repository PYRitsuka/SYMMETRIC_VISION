using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Base
{
    public interface IOpenClose
    {
        public void Open();

        public void Close();
    }
    
    public interface IShowHide
    {
        public void Show();

        public void Hide();
    }

    public interface IChangeColor
    {
        public void ChangeColor();
    }

    public interface IFloatSetControl
    {
        public void Set(float val);

        public float Get();
    }
}
