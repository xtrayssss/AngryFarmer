using Components;
using Constants;
using Leopotam.Ecs;
using StaticsHelper;
using UnityEngine;

namespace Systems
{
    internal sealed class PatrolSystem : IEcsRunSystem
    {
        private EcsFilter<PatrolComponent, EnemyComponent, DirectionComponent, AnimationComponentEnemy>.Exclude<
            FollowComponent> _patrolFilter;

        public void Run()
        {
            foreach (var enemyIndex in _patrolFilter)
            {
                ref var enemyEntity = ref _patrolFilter.GetEntity(enemyIndex);

                ref var movableComponent = ref enemyEntity.Get<MovableComponent>();

                movableComponent.CurrentSpeed = movableComponent.DefaultSpeed;

                ref var enemyComponent = ref _patrolFilter.Get2(enemyIndex);

                ref var animationComponent = ref _patrolFilter.Get4(enemyIndex);

                var enemyPosition = enemyComponent.Transform.position;

                animationComponent.IsAgro = false;

                if (CheckReachedWayPoint(enemyPosition,
                    enemyComponent.WayPoints[enemyComponent.IndexWayPoint].position))
                {
                    enemyComponent.IndexWayPoint =
                        StaticsFunctions.GetRandomIndexObjectInArray(enemyComponent.WayPoints);
                }
            }
        }

        private bool CheckReachedWayPoint(Vector2 enemyPosition, Vector2 wayPosition) =>
            Vector2.Distance(enemyPosition, wayPosition) < GeneralConstants.MINDistanceWayPoint;
    }
}