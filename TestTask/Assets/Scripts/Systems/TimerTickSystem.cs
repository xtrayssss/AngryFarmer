using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class TimerTickSystem : IEcsRunSystem
    {
        private EcsFilter<TimerComponent> _timerFilter;
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