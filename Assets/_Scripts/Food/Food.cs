using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AnimalsDemo
{
    public class Food : MonoBehaviour, ICollectable, IRemoveEventProvider, IResettable
    {
        [SerializeField]
        private GameObject model;

        [SerializeField]
        private GameObject collectedEffect;

        [SerializeField]
        private float showCollectEffectTime = 1f;

        private UnityEvent onRemoveEvent = new UnityEvent();
        public UnityEvent OnRemoveEvent => onRemoveEvent;

        public Transform Transform => transform;

        public void Collect()
        {
            model.SetActive(false);
            collectedEffect.SetActive(true);

            StartCoroutine(WaitAndRemove());
        }

        private IEnumerator WaitAndRemove()
        {
            yield return new WaitForSeconds(showCollectEffectTime);

            onRemoveEvent.Invoke();
        }

        public void ResetState()
        {
            model.SetActive(true);
            collectedEffect.gameObject.SetActive(false);
        }
    }
}
