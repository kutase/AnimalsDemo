using System.Collections;
using System.Collections.Generic;
using AnimalsDemo.Events;
using AnimalsDemo.Utils;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace AnimalsDemo
{
    public class DIInstaller : MonoInstaller
    {
        [SerializeField]
        private CommonPool FoodPool;

        public override void InstallBindings()
        {
            Container.Bind<FoodCollectedEvent>().FromInstance(new FoodCollectedEvent()).AsSingle();
            Container.Bind<FieldUtils>().FromInstance(new FieldUtils()).AsSingle();
            Container.Bind<IObjectPool>().WithId("FoodPool").FromInstance(FoodPool).AsSingle();

            Container.Bind<AnimalsManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<FoodManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<SimulationManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ScreenController>().FromComponentInHierarchy().AsSingle();
        }
    }
}
