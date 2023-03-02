using Leopotam.Ecs;

namespace Interfaces
{
    public interface IFactory
    {
        public EcsEntity GetNewEntity(EcsEntity entity, EcsWorld world, int i);
    }
}