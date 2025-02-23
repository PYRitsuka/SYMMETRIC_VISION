using ScriptableObjects;
using UnityEngine;

namespace UI.Common
{
    public class UIColorManager : MonoBehaviour
    {
        [SerializeField] private UIColor mainColor;
        
        public static UIColorManager Instance { get; private set; }

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }
            Instance = this;
        }

        public Color GetMainColor() => mainColor.GetColor();
    }
}
