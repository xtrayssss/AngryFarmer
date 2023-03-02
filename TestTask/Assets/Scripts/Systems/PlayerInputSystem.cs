using Components;
using Constants;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTag, DirectionComponent> _inputFilter;
        
        public void Run()
        {
            foreach (var playerIndex in this._inputFilter)
            {
                ref var directionComponent = ref _inputFilter.Get2(playerIndex);

                directionComponent.Direction.x = Input.GetAxis(GeneralConstants.Horizontal);

                directionComponent.Direction.y = Input.GetAxis(GeneralConstants.Vertical);
            }
        }
    }
}