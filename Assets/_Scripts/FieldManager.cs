using System.Collections;
using UnityEngine;

namespace AnimalsDemo
{
    public class FieldManager : MonoBehaviour
    {
        [SerializeField]
        private float fieldElementSize = 2f;

        [SerializeField]
        private GameObject fieldElementPrefab;

        private void Awake()
        {
            StartCoroutine(GenerateField(100));
        }

        public IEnumerator GenerateField(int fieldSize)
        {
            for (int x = 0; x < fieldSize; x++)
            {
                for (int z = 0; z < fieldSize; z++)
                {    
                    Instantiate(
                        fieldElementPrefab,
                        new Vector3(
                            x * fieldElementSize - (fieldSize * fieldElementSize) / 2f + fieldElementSize / 2,
                            fieldElementPrefab.transform.position.y,
                            z * fieldElementSize - (fieldSize * fieldElementSize) / 2f + fieldElementSize / 2
                        ),
                        fieldElementPrefab.transform.rotation,
                        transform
                    );

                    yield return null;
                }
            }
        }
    }
}
