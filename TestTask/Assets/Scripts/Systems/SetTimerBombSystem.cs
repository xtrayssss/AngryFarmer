using Components;
using Constants;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class SetTimerBombSystem : IEcsRunSystem
    {
        private EcsFilter<BombComponent> _bombFilter;

        public void Run()
        {
            foreach (var bombEntityIndex in _bombFilter)
            {
                ref var bombComponent = ref _bombFilter.Get1(bombEntityIndex);

                ref var bombEntity = ref _bombFilter.GetEntity(bombEntityIndex);

                if (!bombEntity.Has<TimerComponent>() && bombComponent.BombObject.activeSelf)
                {
                    bombEntity.Get<TimerComponent>().Timer = GeneralConstants.TimerExplosionBomb;
                }
            }
        }
    }
}