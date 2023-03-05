using Components;
using Constants;
using Leopotam.Ecs;
using StaticsHelper;

namespace Systems
{
    internal class DeathSystem : IEcsRunSystem
    {
        private EcsFilter<DeathEvent> _deathFilter;
        private EcsFilter<PlayerComponent, DeathEvent> _playerFilter;
        private EcsFilter<EnemyComponent, DeathEvent> _enemyFilter;
        private EcsFilter<BombComponent, DeathEvent> _bombFilter;
        private EcsFilter<TimerComponent> _timersFilter;

        public void Run()
        {
            foreach (var enemyIndex in _enemyFilter)
            {
                ref var enemyComponent = ref _enemyFilter.Get1(enemyIndex);

                enemyComponent.Transform.gameObject.SetActive(false);
            }

            foreach (var playerIndex in _playerFilter)
            {
                ref var playerComponent = ref _playerFilter.Get1(playerIndex);

                playerComponent.Transform.gameObject.SetActive(false);
               
                StaticsFunctions.InstantiateUIObjectUnderParent(GeneralConstants.LooseGamePanelResourcesName,
                    GeneralConstants.LevelCanvasTag);
                
                foreach (var timerIndex in _timersFilter)
                {
                    ref var timerEntity = ref _timersFilter.GetEntity(timerIndex);

                    timerEntity.Del<TimerComponent>();
                }

            }

            foreach (var bombIndex in _bombFilter)
            {
                ref var bombComponent = ref _bombFilter.Get1(bombIndex);
                bombComponent.BombObject.SetActive(false);
            }

            foreach (var deathIndex in _deathFilter)
            {
                ref var entity = ref _deathFilter.GetEntity(deathIndex);

                entity.Destroy();
            }
        }
    }
}