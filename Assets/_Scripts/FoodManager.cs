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

        [Inject]
        private FoodCollectedEvent foodCollectedEvent;
        
        [Inject]
        private FieldUtils fieldUtils;

        [Inject(Id="FoodPool")]
        private IObjectPool FoodPool;

        private void Awake()
        {
            foodCollectedEvent.AddListener(OnFoodCollected);
        }

        private void OnFoodCollected(ICollector collector)
        {
            var nextFoodPosition = fieldUtils.FindNextFreePosition(collector.Transform.position, collector.MoveSpeed * 5f, foodRadius);

            var food = FoodPool.Create(nextFoodPosition, Quaternion.identity)
                .GetComponent<ICollectable>();

            collector.SetTarget(food);
        }
    }
}
