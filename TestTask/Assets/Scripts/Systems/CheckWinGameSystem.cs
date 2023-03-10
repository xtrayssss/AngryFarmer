using Components;
using Leopotam.Ecs;

namespace Systems
{
    internal class CheckWinGameSystem : IEcsRunSystem
    {
        private EcsFilter<TimerComponent, UITimerTag> _timerFilter;

        private EcsFilter<TimerDestroyComponent> _timerDestroyFilter;

        private EcsFilter<PlayerTag> _playerFilter;

        private EcsEntity _playerEntity;

        private EcsEntity _timerEntity;
        private EcsEntity _timerDestroyEntity;


        public void Run()
        {
            foreach (var playerIndex in _playerFilter)
            {
                _playerEntity = _playerFilter.GetEntity(playerIndex);
            }

            if (_playerEntity.IsAlive())
            {
                foreach (var timerIndex in _timerFilter)
                {
                    ref var timerComponent = ref _timerFilter.Get1(timerIndex);

                    _timerEntity = _timerFilter.GetEntity(timerIndex);

                    if (timerComponent.Timer <= 0)
                    {
                        _playerEntity.Get<WinGameEvent>();
                        _timerEntity.Del<TimerComponent>();
                        _timerDestroyEntity.Del<TimerDestroyComponent>();
                    }
                }
            }
            else
            {
                foreach (var timerDestroyIndex in _timerDestroyFilter)
                {
                    _timerDestroyEntity = _timerDestroyFilter.GetEntity(timerDestroyIndex);
                    _timerDestroyEntity.Del<TimerDestroyComponent>();
                }

                _timerEntity.Del<TimerComponent>();
            }
        }
    }
}