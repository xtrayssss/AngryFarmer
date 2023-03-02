using Components;
using Leopotam.Ecs;

namespace Systems
{
    internal class CalculateDistanceWayPointsSystem : IEcsRunSystem
    {
        private EcsFilter<PatrolComponent, EnemyComponent, DirectionComponent>.Exclude<FollowComponent>
            _calculateFilter;

        public void Run()
        {
            foreach (var enemyIndex in _calculateFilter)
            {
                ref var enemyComponent = ref _calculateFilter.Get2(enemyIndex);

                if (enemyComponent.WayPoints == null) return;

                ref var directionComponent = ref _calculateFilter.Get3(enemyIndex);

                var enemyPosition = enemyComponent.Transform.position;

                directionComponent.Direction =
                    (enemyComponent.WayPoints[enemyComponent.IndexWayPoint].position - enemyPosition)
                    .normalized;
            }
        }
    }
}