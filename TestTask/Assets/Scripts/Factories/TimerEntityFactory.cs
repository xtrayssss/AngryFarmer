using Components;
using Constants;
using Interfaces;
using Leopotam.Ecs;
using Monobehaviors;
using UnityEngine;

namespace Factories
{
    internal class TimerEntityFactory : IEntityFactory
    {
        public EcsEntity GetNewEntity(EcsEntity entity, EcsWorld world, int i)
        {
            entity = world.NewEntity();

            var timerGo = GameObject.FindGameObjectWithTag(GeneralConstants.TimerUITag);
            var timerView = timerGo.GetComponent<TimerUIView>();

            ref var timerUIComponent = ref entity.Get<TimerUIComponent>();

            entity.Get<TimerComponent>().Timer = GeneralConstants.TimerStartSeconds;

            entity.Get<UITimerTag>();

            timerUIComponent.TextMeshPro = timerView.TextMeshPro;

            return entity;
        }
    }
}