using System.Collections;
using AnimalsDemo.Events;
using AnimalsDemo.Utils;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace AnimalsDemo
{
    public class AnimalsManager : MonoBehaviour
    {
        [SerializeField]
        private float animalRadius = 1f;
        
        [SerializeField]
        private GameObject animalPrefab;

        [SerializeField]
        private int animalsCount = 10;

        [Inject]
        private DiContainer container;

        [Inject]
        private FieldUtils fieldUtils;

        private void Start()
        {
            StartCoroutine(GenerateAnimals());
        }

        public IEnumerator GenerateAnimals()
        {
            for (int i = 0; i < animalsCount; i++)
            {
                var position = fieldUtils.FindNextFreePosition(Vector3.zero, animalsCount * 2f, animalRadius);

                var animal = container.InstantiatePrefab(animalPrefab, position, Quaternion.identity, null)
                    .GetComponent<ICollector>();

                yield return null;
            }
        }

//        private Vector3 GetNextFreePosition()
//        {
//            Vector3 position;
//
//            do
//            {
//                position = Quaternion.Euler(0f, Random.Range(0, 360f), 0f) *
//                               (Vector3.forward * (animalsCount * 2f * Random.Range(0f, 1f)));
//            }
//            while (Physics.CheckSphere(position, 1f));
//
//            return position;
//        }
    }
}
