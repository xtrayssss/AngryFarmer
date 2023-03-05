using Leopotam.Ecs;

namespace Interfaces
{
    public interface IEntityFactory
    {
        public EcsEntity GetNewEntity(EcsEntity entity, EcsWorld world, int i);
    }
}