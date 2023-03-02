using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class SpawnEntityBetweenTime : IEcsRunSystem
    {
        private EcsFilter<TimerComponent>.Exclude<UITimerTag> _timerComponent;

        private EcsFilter<SpawnObjectComponent> _poolObjectsFilter;

        private EcsFilter<BombComponent> _bombFilter;

        public void Run()
        {
            foreach (var poolObjectIndex in _poolObjectsFilter)
            {
                ref var timerComponent = ref _timerComponent.Get1(poolObjectIndex);

                ref var poolObject = ref _poolObjectsFilter.Get1(poolObjectIndex);

                if ((int) timerComponent.Timer % poolObject.CoolDownSpawn == 0 &&
                    (int) timerComponent.Timer != timerComponent.LastValueTimer
                    && timerComponent.Indexer < poolObject.PoolObjects.Count)
                {
                    poolObject.PoolObjects[timerComponent.Indexer].SetActive(true);

                    timerComponent.LastValueTimer = (int) timerComponent.Timer;

                    timerComponent.Indexer++;
                }
            }
        }
    }
}