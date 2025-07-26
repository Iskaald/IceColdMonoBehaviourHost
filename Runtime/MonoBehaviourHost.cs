using UnityEngine;

namespace IceCold.MonoBehaviourHost
{
    public class MonoBehaviourHost : MonoBehaviour
    {
        internal static MonoBehaviourHost instance;
        
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
}