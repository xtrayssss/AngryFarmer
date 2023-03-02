using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class FollowSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTag, PlayerComponent> _playerFilter;

        private EcsFilter<FollowComponent, EnemyComponent, DirectionComponent, AnimationComponentEnemy>.Exclude<
            PatrolComponent> _followFilter;

        private const int IndexPlayer = 0;
        
        public void Run()
        {
            foreach (var enemyIndex in _followFilter)
            {
                ref var enemyEntity = ref _followFilter.GetEntity(enemyIndex);

                ref var playerComponent = ref _playerFilter.Get2(IndexPlayer);
                
                ref var movableComponent = ref enemyEntity.Get<MovableComponent>();

                movableComponent.CurrentSpeed = movableComponent.AgroSpeed;

                ref var enemyComponent = ref _followFilter.Get2(enemyIndex);

                ref var directionComponent = ref _followFilter.Get3(enemyIndex);

                ref var animationComponent = ref _followFilter.Get4(enemyIndex);

                var enemyPosition = enemyComponent.Transform.position;

                directionComponent.Direction = Distance(enemyPosition, playerComponent.Transform.position).normalized;

                animationComponent.IsAgro = true;
            }
        }

        private Vector2 Distance(Vector2 currentPosition, Vector2 targetPosition) =>
            targetPosition - currentPosition;
    }
}