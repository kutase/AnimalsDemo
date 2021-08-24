using AnimalsDemo.Events;
using AnimalsDemo.Utils;
using UnityEngine;
using Zenject;

namespace AnimalsDemo
{
    public class FoodManager : MonoBehaviour
    {
        [SerializeField]
        private float foodRadius = 0.5f;

        [SerializeField]
        private GameObject foodPrefab;

        [Inject]
        private FoodCollectedEvent foodCollectedEvent;
        
        [Inject]
        private FieldUtils fieldUtils;

        private void Awake()
        {
            foodCollectedEvent.AddListener(OnFoodCollected);
        }

        private void OnFoodCollected(ICollector collector)
        {
            var nextFoodPosition = fieldUtils.FindNextFreePosition(collector.Transform.position, collector.MoveSpeed * 5f, foodRadius);
//                collector.Transform.position + Quaternion.Euler(0f, Random.Range(0, 360f), 0f) *
//                                   (Vector3.forward * (collector.MoveSpeed * 5f * Random.Range(0f, 1f)));

            var food = Instantiate(foodPrefab, nextFoodPosition, Quaternion.identity)
                .GetComponent<ICollectable>();

            collector.SetTarget(food);
        }
    }
}
