using Components;
using Constants;
using Leopotam.Ecs;

namespace Systems
{
    internal class SetTimersBombSystem : IEcsRunSystem
    {
        private EcsFilter<BombComponent> _bombFilter;

        public void Run()
        {
            foreach (var bombEntityIndex in _bombFilter)
            {
                ref var bombComponent = ref _bombFilter.Get1(bombEntityIndex);

                ref var bombEntity = ref _bombFilter.GetEntity(bombEntityIndex);

                if (CheckSetTimers<TimerComponent>(bombEntity, bombComponent))
                {
                    ref var timerComponent = ref bombEntity.Get<TimerComponent>();

                    timerComponent.Timer = GeneralConstants.TimerExplosionBomb;
                }
            }
        }

        private bool CheckSetTimers<T>(EcsEntity bombEntity, BombComponent bombComponent) where T : struct =>
            !bombEntity.Has<T>() && bombComponent.BombObject.activeSelf;
    }
}