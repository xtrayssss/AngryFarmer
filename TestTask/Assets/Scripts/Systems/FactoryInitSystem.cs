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

        private readonly IFactory _enemyFactory = new EnemyFactory();
        private readonly IFactory _playerFactory = new PlayerFactory();
        private readonly IFactory _bombFactory = new BombFactory();
        private readonly IFactory _timerUIFactory = new TimerFactory();
        private readonly IFactory _poolObject = new PoolObjectFactory();

        private EcsEntity _enemyEntity;
        private EcsEntity _bombEntity;
        private EcsEntity _playerEntity;
        private EcsEntity _timerUIEntity;
        private EcsEntity _poolObjectEntity;
        
        public void Init()
        {
            for (int i = 0; i < GeneralConstants.AmountEnemies; i++)
            {
                _enemyEntity = _enemyFactory.GetNewEntity(_enemyEntity, _world, i);
            }

            for (int i = 0; i < GeneralConstants.AmountBombs; i++)
            {
                _bombEntity = _bombFactory.GetNewEntity(_bombEntity, _world, i);
            }

            for (int i = 0; i < GeneralConstants.AmountPoolObjects; i++)
            {
                _poolObjectEntity = _poolObject.GetNewEntity(_poolObjectEntity, _world, i);
            }

            _playerEntity = _playerFactory.GetNewEntity(_playerEntity, _world, 0);

            _timerUIEntity = _timerUIFactory.GetNewEntity(_timerUIEntity, _world, 0);
        }
    }
}