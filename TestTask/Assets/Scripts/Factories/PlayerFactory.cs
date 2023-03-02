using Components;
using Constants;
using Enums;
using Interfaces;
using Leopotam.Ecs;
using Monobehaviors;
using UnityEngine;

namespace Factories
{
    internal class PlayerFactory : IFactory
    {
        public EcsEntity GetNewEntity(EcsEntity entity, EcsWorld world, int i)
        {
            entity = world.NewEntity();

            SetComponentEntity(entity);
            
            ref var healthComponent = ref entity.Get<HealthComponent>();

            ref var animationComponent = ref entity.Get<AnimationComponentPlayer>();

            ref var attackCooldownComponent = ref entity.Get<AttackCoolDownComponent>();

            ref var playerComponent = ref entity.Get<PlayerComponent>();

            ref var movableComponent = ref entity.Get<MovableComponent>();
            
            var playerGO = GameObject.FindGameObjectWithTag(GeneralConstants.PlayerTag);

            entity.Get<ModelEntityComponent>().Rigidbody2D = playerGO.GetComponent<Rigidbody2D>(); 

            var playerData = playerGO.GetComponent<PlayerView>().PlayerData;

            playerComponent.PlayerData = playerData;

            SetComponent(playerGO, entity, ref animationComponent, ref playerComponent);

            SetVariables(ref attackCooldownComponent, ref healthComponent, ref playerComponent, ref movableComponent);
            
            return entity;
        }

        private void SetComponent(GameObject playerGO, EcsEntity playerEntity,
            ref AnimationComponentPlayer animationComponent, ref PlayerComponent playerComponent)
        {
            var playerView = playerGO.GetComponent<PlayerView>();

            playerView.PlayerEntity = playerEntity;

            playerComponent.Transform = playerGO.transform;

            playerComponent.Rigidbody = playerGO.GetComponent<Rigidbody2D>();

            playerComponent.Collider2D = playerGO.GetComponent<Collider2D>();

            animationComponent.Animator = playerGO.GetComponentInChildren<Animator>();
        }

        private void SetVariables(ref AttackCoolDownComponent attackCooldownComponent,
            ref HealthComponent healthComponent, ref PlayerComponent playerComponent,
            ref MovableComponent movableComponent)
        {
            attackCooldownComponent.TotalSecondsCollDownAttack = GeneralConstants.TotalSecondsCollDownAttackPlayer;

            healthComponent.Health = playerComponent.PlayerData.MAXHealth;

            healthComponent.Damage = playerComponent.PlayerData.DamagesEntity[(int) EnumDamagedForPlayer.EnemyDamage];

            movableComponent.CurrentSpeed = playerComponent.PlayerData.speed;
        }
        private static void SetComponentEntity(EcsEntity playerEntity)
        {
            playerEntity.Get<PlayerTag>();

            playerEntity.Get<DirectionComponent>();

            playerEntity.Get<PlayerInputComponent>();
        }
    }
}