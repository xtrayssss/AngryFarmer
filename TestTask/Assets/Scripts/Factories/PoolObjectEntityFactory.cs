using Components;
using Constants;
using Interfaces;
using Leopotam.Ecs;
using Monobehaviors;
using UnityEngine;

namespace Factories
{
    internal class PoolObjectEntityFactory : IEntityFactory
    {
        public EcsEntity GetNewEntity(EcsEntity entity, EcsWorld world, int i)
        {
            entity = world.NewEntity();

            ref var poolObjectComponent = ref entity.Get<SpawnObjectComponent>();

            if (i == 1)
            {
                poolObjectComponent.PoolObjects =
                    GameObject.FindObjectOfType<ContainerGameObjectEntities>().EnemyPoolObjects;

                poolObjectComponent.CoolDownSpawn = 5.0f;

                entity.Get<TimerComponent>().Timer = GeneralConstants.TimerStartSeconds;
            }

            if (i == 0)
            {
                poolObjectComponent.PoolObjects =
                    GameObject.FindObjectOfType<ContainerGameObjectEntities>().BombPoolObjecs;


                poolObjectComponent.CoolDownSpawn = 3.0f;

                entity.Get<TimerComponent>().Timer = GeneralConstants.TimerStartSeconds;
            }


            return entity;
        }
    }
}