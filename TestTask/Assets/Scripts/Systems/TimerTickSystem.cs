using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class TimerTickSystem : IEcsRunSystem
    {
        private EcsFilter<TimerComponent> _timerFilter;
        private EcsFilter<TimerDestroyComponent> _timerDestroyFilter;
        private EcsFilter<TimerRespawnComponent> _timerRespawnFilter;

        public void Run()
        {
            foreach (var timerIndex in _timerFilter)
            {
                ref var timerComponent = ref _timerFilter.Get1(idx: timerIndex);

                timerComponent.Timer -= Time.deltaTime;

                timerComponent.Timer = Mathf.Clamp(timerComponent.Timer, 0, timerComponent.Timer);
            }
        }
    }
}