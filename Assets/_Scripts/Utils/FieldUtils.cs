using UnityEngine;

namespace AnimalsDemo.Utils
{
    public class FieldUtils
    {
        public Vector3 FindNextFreePosition(Vector3 center, float distance, float checkRadius)
        {
            Vector3 position;

            do
            {
                position = center + Quaternion.Euler(0f, Random.Range(0, 360f), 0f) *
                           (Vector3.forward * (distance * Random.Range(0f, 1f)));
            }
            while (Physics.CheckSphere(position, checkRadius));

            return position;
        }
    }
}
