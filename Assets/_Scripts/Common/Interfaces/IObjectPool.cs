using UnityEngine;

namespace AnimalsDemo
{
    public interface IObjectPool
    {
        GameObject Create(Vector3 position, Quaternion rotation);
        void Remove(GameObject gameObject);
    }
}
