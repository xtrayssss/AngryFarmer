using Components;
using Constants;
using Enums;
using Leopotam.Ecs;
using UnityEngine;

namespace Monobehaviors
{
    public class EnemyZoneHandler : MonoBehaviour
    {
        private EcsWorld _world;
        
        private EnemyView _enemyView;

        private void Start()
        {
            _enemyView = GetComponentInParent<EnemyView>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (CheckCollidedObject(other, GeneralConstants.PlayerTag))
            {
                _enemyView.Entity.Get<DamageComponent>();
                
                ref var enemyComponent = ref _enemyView.Entity.Get<EnemyComponent>();
                ref var healthComponent = ref _enemyView.Entity.Get<HealthComponent>();

                healthComponent.Damage = enemyComponent.EnemyData.DamagesEntity[(int) EnumDamagedForEnemy.PlayerDamage];
            }

            if (CheckCollidedObject(other, GeneralConstants.PlayerTag) && !_enemyView.allowPatrolling)
            {
                _enemyView.Entity.Get<FollowComponent>();
            }

            if (CheckCollidedObject(other, GeneralConstants.PlayerTag) && _enemyView.allowPatrolling)
            {
                _enemyView.Entity.Get<FollowComponent>();
                _enemyView.Entity.Del<PatrolComponent>();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (CheckCollidedObject(other,GeneralConstants.PlayerTag))
            {
                _enemyView.Entity.Del<DamageComponent>();
            }

            if (CheckCollidedObject(other,GeneralConstants.PlayerTag) && !_enemyView.allowPatrolling)
            {
                _enemyView.Entity.Del<FollowComponent>();
            }

            if (CheckCollidedObject(other, GeneralConstants.PlayerTag) && _enemyView.allowPatrolling)
            {
                _enemyView.Entity.Get<PatrolComponent>();
                _enemyView.Entity.Del<FollowComponent>();
            }
        }

        private bool CheckCollidedObject(Collider2D other, string tagObject) =>
            other.CompareTag(tagObject);
    }
}