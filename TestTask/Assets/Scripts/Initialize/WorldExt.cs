using Leopotam.Ecs;

namespace Initialize
{
    public static class WorldExt
    {
        public static void SendMessage<T>(this EcsWorld world, out EcsEntity entity, in T message) where T : struct
        {
            var newEntity = world.NewEntity();
            newEntity.Get<T>() = message;

            entity = newEntity;
        }

        public static void CreateEntity(this  EcsWorld world,out EcsEntity entity)
        {      
            entity = world.NewEntity();
        }
        
    }
}