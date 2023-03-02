using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class AttackBlockSystem : IEcsRunSystem
    {
        private EcsFilter<BlockAttack> _blockAttackFilter;
        public void Run()
        {
            foreach (var entityIndex in _blockAttackFilter)
            {
                ref var blockAttackComponent = ref _blockAttackFilter.Get1(entityIndex);
                ref var entity = ref _blockAttackFilter.GetEntity(entityIndex);
                
                blockAttackComponent.AttackCooldown -= Time.deltaTime;

                if (blockAttackComponent.AttackCooldown <= 0)
                {
                    entity.Del<BlockAttack>();    
                }
            }
        }
    }
}