using System.Collections;
using IceCold.Interface;
using IceCold.MonoBehaviourHost.Interface;
using UnityEngine;

namespace IceCold.MonoBehaviourHost
{
    [ServicePriority(1)]
    public class MonoBehaviourHostService : IMonoBehaviourHostService
    {
        public bool IsInitialized { get; private set; }
        
        private MonoBehaviourHost host = null;
        private GameObject coreRoot = null;
        
        public void Initialize()
        {
            CreateHostObject();
            IsInitialized = true;
        }

        public void Deinitialize()
        {
            IsInitialized = false;
        }
        
        public void OnWillQuit() { }

        private void CreateHostObject()
        {
            if (coreRoot == null)
            {
                coreRoot = new GameObject("[Core]");
                Object.DontDestroyOnLoad(coreRoot);
            }
            
            if (MonoBehaviourHost.instance == null)
            {
                host = coreRoot.AddComponent<MonoBehaviourHost>();
            }
            else
            {
                host = MonoBehaviourHost.instance;
                host?.transform.SetParent(coreRoot.transform);
            }
        }

        public void StartCoroutine(IEnumerator routine)
        {
            host?.StartCoroutine(routine);
        }

        public void StopCoroutine(IEnumerator routine)
        {
            host?.StopCoroutine(routine);
        }

        public void StopAllCoroutines()
        {
            host?.StopAllCoroutines();
        }

        public void AddComponentOfTypeToRoot<T>() where T : Component
        {
            if (coreRoot == null) CreateHostObject();
            if (coreRoot!.GetComponent<T>() == null)
                coreRoot.AddComponent<T>();
        }

        public GameObject AddEmptyGameObjectToRoot(string name)
        {
            if (coreRoot == null) CreateHostObject();
            var newObj = new GameObject(name);
            newObj.transform.SetParent(coreRoot!.transform);
            
            return newObj;
        }
    }
}