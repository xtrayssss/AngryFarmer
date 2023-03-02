using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<DirectionComponent, MovableComponent, ModelEntityComponent> _moveFilter;
        public void Run()
        {
            foreach (var entityIndex in _moveFilter)
            {
                ref var directionComponent = ref _moveFilter.Get1(entityIndex);

                ref var movableComponent = ref _moveFilter.Get2(entityIndex);

                ref var modeComponent = ref _moveFilter.Get3(entityIndex);
                
                directionComponent.DirectionCalculated = directionComponent.Direction.normalized *
                                    (movableComponent.CurrentSpeed * Time.deltaTime);
                
                modeComponent.Rigidbody2D.MovePosition(
                    modeComponent.Rigidbody2D.position + directionComponent.DirectionCalculated);
            }
        }
    }
}