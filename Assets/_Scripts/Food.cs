using UnityEngine;

namespace AnimalsDemo
{
    public class Food : MonoBehaviour, ICollectable
    {
        public Transform Transform => transform;
        
        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}
