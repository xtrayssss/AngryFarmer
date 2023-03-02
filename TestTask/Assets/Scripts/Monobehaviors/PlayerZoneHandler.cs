using System;
using Components;
using Constants;
using Enums;
using Leopotam.Ecs;
using UnityEngine;

namespace Monobehaviors
{
    public class PlayerZoneHandler : MonoBehaviour
    {
        private PlayerView _playerView;

        private void Start()
        {
            _playerView = GetComponent<PlayerView>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (CheckCollidedObject(other, GeneralConstants.EnemyTag))
            {
                _playerView.PlayerEntity.Get<DamageComponent>();

                GetComponent((int) EnumDamagedForPlayer.EnemyDamage);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (CheckCollidedObject(other, GeneralConstants.EnemyTag))
            {
                _playerView.PlayerEntity.Del<DamageComponent>();
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (CheckCollidedObject(other, GeneralConstants.BombTag) &&
                other.GetComponent<BombView>().BombEntity.Get<TimerComponent>().Timer <= 0)
            {
                _playerView.PlayerEntity.Get<DamageComponent>();

                GetComponent((int) EnumDamagedForPlayer.BombDamage);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (CheckCollidedObject(other, GeneralConstants.BombTag))
            {
                _playerView.PlayerEntity.Del<DamageComponent>();
            }
        }

        private static bool CheckCollidedObject(Collision2D other, string tag) =>
            other.gameObject.CompareTag(tag);

        private static bool CheckCollidedObject(Collider2D other, string tag) =>
            other.gameObject.CompareTag(tag);

        private void GetComponent(int index)
        {
            ref var playerComponent = ref _playerView.PlayerEntity.Get<PlayerComponent>();
            ref var healthComponent = ref _playerView.PlayerEntity.Get<HealthComponent>();
            healthComponent.Damage = playerComponent.PlayerData.DamagesEntity[index];
        }
    }
}