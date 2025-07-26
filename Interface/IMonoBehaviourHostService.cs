using System.Collections;
using IceCold.Interface;
using UnityEngine;

namespace IceCold.MonoBehaviourHost.Interface
{
    public interface IMonoBehaviourHostService : ICoreService
    {
        public void StartCoroutine(IEnumerator routine);
        public void StopCoroutine(IEnumerator routine);
        public void StopAllCoroutines();
        
        public void AddComponentOfTypeToRoot<T>() where T : Component;
        public GameObject AddEmptyGameObjectToRoot(string name);
    }
}