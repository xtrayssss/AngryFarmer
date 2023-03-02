using Components;
using Constants;
using Interfaces;
using Leopotam.Ecs;
using Monobehaviors;
using UnityEngine;


namespace Factories
{
    internal class BombFactory : IFactory
    {
        private readonly string[] _paths =
        {
            "EnemiesPrefabs/Bomb (1)",
            "EnemiesPrefabs/Bomb (2)",
            "EnemiesPrefabs/Bomb (3)",
            "EnemiesPrefabs/Bomb (4)",
            "EnemiesPrefabs/Bomb (5)"
        };

        public EcsEntity GetNewEntity(EcsEntity entity, EcsWorld world, int i)
        {
            entity = world.NewEntity();

            var bombGO = Instantiate(i);

            bombGO.transform.position = new Vector3(Random.Range(GeneralConstants.LeftX, GeneralConstants.RightX),
                Random.Range(GeneralConstants.DownY, GeneralConstants.TopY), 1);

            ref var bombComponent = ref entity.Get<BombComponent>();

            ref var bombHealthComponent = ref entity.Get<HealthComponent>();

            var bombView = bombGO.GetComponent<BombView>();

            SetMonobehaviorVariables(entity, i, bombView, bombGO, ref bombComponent, ref bombHealthComponent);

            bombGO.SetActive(false);

            GameObject.FindObjectOfType<ContainerGameObjectEntities>().BombPoolObjecs.Add(bombGO);

            bombComponent.BombObject = bombGO;

            return entity;
        }

        private GameObject Instantiate(int i) =>
            GameObject.Instantiate(Resources.Load(_paths[i]),
                GameObject.FindGameObjectWithTag(GeneralConstants.ContainerEnemyTag).transform) as GameObject;

        private static void SetMonobehaviorVariables(EcsEntity entity, int i, BombView bombView,
            GameObject bombGO, ref BombComponent bombComponent,
            ref HealthComponent bombHealthComponent)
        {
            bombView.BombEntity = entity;

            bombComponent.BombEntity = entity;

            bombComponent.BombData = bombView.BombData;

            bombComponent.BombObject = bombGO;

            bombHealthComponent.Health = bombComponent.BombData.MAXHealth;
        }
    }
}