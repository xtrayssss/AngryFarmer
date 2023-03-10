using Components;
using Leopotam.Ecs;

namespace Systems
{
    internal struct DamagedSystem : IEcsRunSystem
    {
        private EcsFilter<DamageComponent, HealthComponent>.Exclude<BlockAttack> _damageFilter;

        public void Run()
        {
            foreach (var entityIndex in _damageFilter)
            {
                ref var entityDamaged = ref _damageFilter.GetEntity(entityIndex);

                ref var healthComponent = ref _damageFilter.Get2(entityIndex);

                ref var blockAttack = ref entityDamaged.Get<BlockAttack>();

                healthComponent.Health -= healthComponent.Damage;

                blockAttack.AttackCooldown = 1;
            }
        }
    }
}