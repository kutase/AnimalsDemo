using AnimalsDemo.Events;
using UnityEngine;
using Zenject;

namespace AnimalsDemo
{
    public class Animal : MonoBehaviour, ICollector
    {
        public Transform Transform => transform;

        [SerializeField]
        private float moveSpeed = 10f;

        public float MoveSpeed => moveSpeed;

        private ICollectable food;

        [Inject]
        private FoodCollectedEvent foodCollectedEvent;

        private void Awake()
        {
            foodCollectedEvent.Invoke(this);
        }

        private void FixedUpdate()
        {
            if (food == null)
            {
                return;
            }

            var targetPosition = food.Transform.position;
            var currentPosition = transform.position;

            var direction = (targetPosition - currentPosition);

            if (direction.magnitude <= 0.5f)
            {
                food.Collect();
                foodCollectedEvent.Invoke(this);
                return;
            }

            transform.position += transform.forward * moveSpeed * Time.fixedDeltaTime;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }

        public void SetTarget(ICollectable collectable)
        {
            food = collectable;
        }

        public void SetSpeed(float speed)
        {
            moveSpeed = speed;
        }
    }
}
