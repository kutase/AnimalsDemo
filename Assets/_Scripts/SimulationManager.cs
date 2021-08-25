using UnityEngine;
using Zenject;

namespace AnimalsDemo
{
    public class SimulationManager : MonoBehaviour
    {
        [Inject]
        private AnimalsManager animalsManager;

        public void StartSimulation(float fieldSize, int animalsCount, float animalSpeed)
        {
            animalsManager.GenerateAnimals(fieldSize, animalsCount, animalSpeed);
        }

        public void SetSimulationSpeed(float simulationSpeed)
        {
            Time.timeScale = simulationSpeed;
        }
    }
}
