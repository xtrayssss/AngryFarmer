using Systems;
using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Initialize
{
    public class Startup : MonoBehaviour
    {
        private EcsWorld _world;

        #region Systems

        private EcsSystems _initSystem;
        private EcsSystems _systemFixedUpdate;
        private EcsSystems _systemUpdate;

        #endregion

        private void Start()
        {
            _world = new EcsWorld();

            _systemUpdate = new EcsSystems(_world);

            _initSystem = new EcsSystems(_world);

            _systemFixedUpdate = new EcsSystems(_world);

            AddSystems();

            AddOneFrames();

            _initSystem.Init();
            _systemUpdate.Init();
            _systemFixedUpdate.Init();
        }
        
        private void AddOneFrames()
        {
            _systemUpdate
                .Add(new DeathSystem())
                .OneFrame<WinGameEvent>();
        }

        private void AddSystems()
        {
            _initSystem
                .Add(new FactoryInitSystem());
            _systemUpdate
                .Add(new PlayerInputSystem())
                .Add(new AnimatorSystem())
                .Add(new CalculateDistanceWayPointsSystem())
                .Add(new DamagedSystem())
                .Add(new AttackBlockSystem())
                .Add(new TimerTickSystem())
                .Add(new CheckWinGameSystem())
                .Add(new DeathEntityCheckerSystem())
                .Add(new WinGameSystem())
                .Add(new SpawnEntityBetweenTime())
                .Add(new SetTextTimerUI())
                .Add(new SetTimersBombSystem());
            _systemFixedUpdate
                .Add(new PlayerInputSystem())
                .Add(new MoveSystem())
                .Add(new FollowSystem())
                .Add(new PatrolSystem());
        }

        private void Update()
        {
            _systemUpdate.Run();
        }

        private void FixedUpdate()
        {
            _systemFixedUpdate.Run();
        }

        private void OnDestroy()
        {
            _initSystem.Destroy();
            _systemFixedUpdate.Destroy();
            _systemUpdate.Destroy();
            _world.Destroy();
        }
    }
}