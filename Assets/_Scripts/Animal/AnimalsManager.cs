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

        [Inject]
        private DiContainer container;

        [Inject]
        private FieldUtils fieldUtils;

        [Inject]
        private FoodManager foodManager;

        public void GenerateAnimals(float fieldSize, int animalsCount, float animalSpeed)
        {
            var maxRadius = fieldSize / 2f;

            foodManager.SetMaxRadius(maxRadius);
            
            StartCoroutine(GenerateAnimalsProcess(maxRadius, animalsCount, animalSpeed));
        }

        public IEnumerator GenerateAnimalsProcess(float maxRadius, int animalsCount, float animalSpeed)
        {
            for (int i = 0; i < animalsCount; i++)
            {
                var position = fieldUtils.FindNextFreePosition(Vector3.zero, maxRadius, animalRadius);

                var animal = container.InstantiatePrefab(animalPrefab, position, Quaternion.identity, null)
                    .GetComponent<ICollector>();

                animal.SetSpeed(animalSpeed);

                yield return null;
            }
        }
    }
}
