using System.Collections.Generic;
using UnityEngine;

namespace AnimalsDemo
{
    public class CommonPool : MonoBehaviour, IObjectPool
    {
        [SerializeField]
        private GameObject objectPrefab;

        [SerializeField]
        private int preInstantiateNumber = 10;

        private List<GameObject> pooledObjects = new List<GameObject>();

        private void Awake()
        {
            for (int i = 0; i < preInstantiateNumber; i++)
            {
                var poolObject = InstantiateAndPrepareObject(objectPrefab);

                pooledObjects.Add(poolObject);
            }
        }

        private GameObject InstantiateAndPrepareObject(GameObject prefab)
        {
            var poolObject = Instantiate(prefab, transform);
            poolObject.SetActive(false);

            var removeEventProvider = poolObject.GetComponent<IRemoveEventProvider>();
            removeEventProvider?.OnRemoveEvent.AddListener(() =>
            {
                Remove(poolObject);
            });

            return poolObject;
        }

        public GameObject Create(Vector3 position, Quaternion rotation)
        {
            foreach (var pooledObject in pooledObjects)
            {
                if (!pooledObject.activeInHierarchy)
                {
                    pooledObject.transform.SetPositionAndRotation(position, rotation);

                    var resetter = pooledObject.GetComponent<IResettable>();
                    resetter?.ResetState();

                    pooledObject.SetActive(true);
                    return pooledObject;
                }
            }

            var newPoolObject = InstantiateAndPrepareObject(objectPrefab);
            newPoolObject.transform.SetPositionAndRotation(position, rotation);
            newPoolObject.SetActive(true);

            return newPoolObject;
        }

        public void Remove(GameObject poolObject)
        {
            poolObject.SetActive(false);
        }
    }
}
