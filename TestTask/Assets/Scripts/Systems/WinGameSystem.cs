using Components;
using Constants;
using Leopotam.Ecs;
using StaticsHelper;
using Unity.VisualScripting;
using UnityEngine;

namespace Systems
{
    internal class WinGameSystem : IEcsRunSystem
    {
        private EcsFilter<WinGameEvent> _winGameFilter;

        private EcsFilter<WinGameEvent> _playerFilter;

        public void Run()
        {
            foreach (var playerIndex in _playerFilter)
            {
                ref var playerEntity = ref _playerFilter.GetEntity(playerIndex);
                
                playerEntity.Del<MovableComponent>();
                playerEntity.Del<AnimationComponentPlayer>();
                playerEntity.Get<PlayerComponent>().Transform.GameObject().SetActive(false);

                InstantiateUI();
            }
        }

        private void InstantiateUI()
        {
            StaticsFunctions.InstantiateUIObjectUnderParent(GeneralConstants.WinGamePanelResourcesName,
                GeneralConstants.LevelCanvasTag);
        }
    }
}