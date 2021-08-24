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
        public override void InstallBindings()
        {
            Container.Bind<FoodCollectedEvent>().FromInstance(new FoodCollectedEvent()).AsSingle();
            Container.Bind<FieldUtils>().FromInstance(new FieldUtils()).AsSingle();
        }
    }
}
