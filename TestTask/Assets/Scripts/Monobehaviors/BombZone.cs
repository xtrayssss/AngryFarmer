using Components;
using Constants;
using Enums;
using Leopotam.Ecs;
using UnityEngine;

namespace Monobehaviors
{
    internal class BombZone : MonoBehaviour
    {
        private BombView _bombView;

        private void Start()
        {
            _bombView = GetComponentInParent<BombView>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag(GeneralConstants.PlayerTag) && _bombView.BombEntity.Get<TimerComponent>().Timer <= 0)
            {
                _bombView.BombEntity.Get<DamageComponent>();

                ref var healthComponent = ref _bombView.BombEntity.Get<HealthComponent>();

                healthComponent.Damage = _bombView.BombData.DamagesEntity[(int) EnumDamagedForBomb.PlayerDamage];
            }
        }
    }
}