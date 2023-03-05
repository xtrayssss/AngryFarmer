using System.Collections.Generic;
using Constants;
using Factories;
using Interfaces;
using Leopotam.Ecs;

namespace Systems
{
    internal class FactoryInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;

        private readonly IEntityFactory _enemyEntityFactory = new EnemyEntityFactory();
        private readonly IEntityFactory _playerEntityFactory = new PlayerEntityFactory();
        private readonly IEntityFactory _bombEntityFactory = new BombEntityFactory();
        private readonly IEntityFactory _timerUIEntityFactory = new TimerEntityFactory();
        private readonly IEntityFactory _poolObject = new PoolObjectEntityFactory();

        private EcsEntity _enemyEntity;
        private EcsEntity _bombEntity;
        private EcsEntity _playerEntity;
        private EcsEntity _timerUIEntity;
        private EcsEntity _poolObjectEntity;
        
        public void Init()
        {
            for (int i = 0; i < GeneralConstants.AmountEnemies; i++)
            {
                _enemyEntity = _enemyEntityFactory.GetNewEntity(_enemyEntity, _world, i);
            }

            for (int i = 0; i < GeneralConstants.AmountBombs; i++)
            {
                _bombEntity = _bombEntityFactory.GetNewEntity(_bombEntity, _world, i);
            }

            for (int i = 0; i < GeneralConstants.AmountPoolObjects; i++)
            {
                _poolObjectEntity = _poolObject.GetNewEntity(_poolObjectEntity, _world, i);
            }

            _playerEntity = _playerEntityFactory.GetNewEntity(_playerEntity, _world, 0);

            _timerUIEntity = _timerUIEntityFactory.GetNewEntity(_timerUIEntity, _world, 0);
        }
    }
}