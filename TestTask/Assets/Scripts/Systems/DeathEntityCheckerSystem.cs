using Components;
using Leopotam.Ecs;

namespace Systems
{
    internal class DeathEntityCheckerSystem : IEcsRunSystem
    {
        private EcsFilter<HealthComponent> _deathFilter;

        public void Run()
        {
            foreach (var entityIndex in _deathFilter)
            {
                ref var healthComponent = ref _deathFilter.Get1(entityIndex);
                
                if (IsDeath(ref healthComponent))
                {
                    ref var entity = ref _deathFilter.GetEntity(entityIndex);

                    entity.Get<DeathEvent>();
                }
            }
        }

        private bool IsDeath(ref HealthComponent healthComponent) => 
            healthComponent.Health <= 0;
    }
}