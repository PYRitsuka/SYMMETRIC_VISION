using UnityEngine;

namespace Common
{
    public class DontDestroyOnLoadRoot : MonoBehaviour
    {
        public static DontDestroyOnLoadRoot Root { get; private set; }
        
        // Start is called before the first frame update
        void Awake()
        {
            DontDestroyOnLoad(this);
            if (Root != null)
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).parent = Root.transform;
                }
                Destroy(gameObject);
            }
            else
            {
                Root = this;
            }
        }

        public static AudioSource GetAudioSource() => Root.GetComponent(typeof(AudioSource)) as AudioSource;
    }
}
