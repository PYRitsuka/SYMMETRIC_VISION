using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "创建一个UI颜色")]
    public class UIColor : ScriptableObject
    {
        [Header("颜色"), SerializeField]
        private Color m_color;
        
        public Color GetColor() => m_color;
    }
}
