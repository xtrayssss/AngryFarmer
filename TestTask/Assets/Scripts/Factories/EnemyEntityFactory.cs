using System.Linq;
using Systems;
using Components;
using Constants;
using Interfaces;
using Leopotam.Ecs;
using Monobehaviors;
using StaticsHelper;
using Unity.VisualScripting;
using UnityEngine;

namespace Factories
{
    public class EnemyEntityFactory : IEntityFactory
    {
        private readonly string[] _paths =
        {
            "EnemiesPrefabs/Farmer (1)",
            "EnemiesPrefabs/Farmer (2)",
            "EnemiesPrefabs/Farmer (3)",
            "EnemiesPrefabs/Farmer (4)",
            "EnemiesPrefabs/Farmer (6)",
            "EnemiesPrefabs/Farmer (7)"
        };

        public EcsEntity GetNewEntity(EcsEntity entity, EcsWorld world, int i)
        {
            entity = world.NewEntity();

            GameObject enemyGO = Instantiate(i);

            enemyGO.transform.position = new Vector3(Random.Range(GeneralConstants.LeftX, GeneralConstants.RightX),
                Random.Range(GeneralConstants.DownY, GeneralConstants.TopY), 1);

            var enemyView = enemyGO.GetComponent<EnemyView>();

            enemyView.Entity = entity;

            SetAllowPatrolling(ref entity, enemyView);

            entity.Get<DirectionComponent>();

            ref var modelEntityComponent = ref entity.Get<ModelEntityComponent>();

            modelEntityComponent.Rigidbody2D = enemyGO.GetComponent<Rigidbody2D>();
            modelEntityComponent.EntityModel = enemyGO.gameObject.transform;

            ref var enemyComponent = ref entity.Get<EnemyComponent>();

            ref var animationComponent = ref entity.Get<AnimationComponentEnemy>();

            ref var healthComponent = ref entity.Get<HealthComponent>();

            ref var attackCooldownComponent = ref entity.Get<AttackCoolDownComponent>();

            enemyComponent.EnemyData = enemyView.EnemyData;

            attackCooldownComponent.TotalSecondsCollDownAttack = GeneralConstants.TotalSecondsCollDownAttackEnemy;

            SetMonobehaviorComponent(enemyView, i, ref animationComponent, ref enemyComponent);

            SetWayPoints(entity);

            ref var movableComponent = ref entity.Get<MovableComponent>();

            SetVariables(ref enemyComponent, ref healthComponent, ref movableComponent);

            enemyGO.GameObject().SetActive(false);

            GameObject.FindObjectOfType<ContainerGameObjectEntities>().EnemyPoolObjects.Add(enemyGO);

            return entity;
        }

        private void SetAllowPatrolling(ref EcsEntity entity, EnemyView enemyView)
        {
            if (enemyView.allowPatrolling)
            {
                entity.Get<PatrolComponent>();
            }
            else
            {
                entity.Get<FollowComponent>();
            }
        }

        private GameObject Instantiate(int i) =>
            GameObject.Instantiate(Resources.Load(_paths[i]),
                GameObject.FindGameObjectWithTag(GeneralConstants.ContainerEnemyTag).transform) as GameObject;

        private void SetVariables(ref EnemyComponent enemyComponent, ref HealthComponent healthComponent,
            ref MovableComponent movableComponent)
        {
            enemyComponent.IndexWayPoint = StaticsFunctions.GetRandomIndexObjectInArray(enemyComponent.WayPoints);

            healthComponent.Health = enemyComponent.EnemyData.MAXHealth;

            healthComponent.Damage = enemyComponent.EnemyData.Damage;

            movableComponent.DefaultSpeed = enemyComponent.EnemyData.DefaultSpeed;

            movableComponent.AgroSpeed = enemyComponent.EnemyData.AgroSpeed;
        }

        private void SetWayPoints(EcsEntity enemyEntity) =>
            enemyEntity.Get<EnemyComponent>().WayPoints =
                Object.FindObjectsOfType<WayPoint>()
                    .Where(x => x.CompareTag(GeneralConstants.WayPointTag))
                    .Select(x => x.transform).ToArray();

        private void SetMonobehaviorComponent(EnemyView enemyGO, int i,
            ref AnimationComponentEnemy animationComponent,
            ref EnemyComponent enemyComponent)
        {
            enemyComponent.Rigidbody = enemyGO.GetComponent<Rigidbody2D>();

            enemyComponent.Transform = enemyGO.transform;

            enemyComponent.Collider2D = enemyGO.GetComponent<Collider2D>();

            animationComponent.Animator = enemyGO.GetComponentInChildren<Animator>();
        }
    }
}