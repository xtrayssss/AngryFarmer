using Systems;
using Components;
using Constants;
using Interfaces;
using Leopotam.Ecs;
using Monobehaviors;
using UnityEngine;


namespace Factories
{
    internal class BombEntityFactory : IEntityFactory
    {
        public EcsEntity GetNewEntity(EcsEntity entity, EcsWorld world, int i)
        {
            entity = world.NewEntity();

            var bombGO = Instantiate(i);

            bombGO.transform.position = new Vector3(Random.Range(GeneralConstants.LeftX, GeneralConstants.RightX),
                Random.Range(GeneralConstants.DownY, GeneralConstants.TopY), 1);

            ref var bombComponent = ref entity.Get<BombComponent>();

            ref var bombHealthComponent = ref entity.Get<HealthComponent>();

            var bombView = bombGO.GetComponent<BombView>();

            SetMonobehaviorVariables(entity, bombView, bombGO, ref bombComponent, ref bombHealthComponent);

            bombGO.SetActive(false);

            GameObject.FindObjectOfType<ContainerGameObjectEntities>().BombPoolObjecs.Add(bombGO);

            bombComponent.BombObject = bombGO;

            ref var modelEntityComponent = ref entity.Get<ModelEntityComponent>();

            modelEntityComponent.Rigidbody2D = bombGO.GetComponent<Rigidbody2D>();
            modelEntityComponent.EntityModel = bombGO.gameObject.transform;

            return entity;
        }

        private GameObject Instantiate(int i) =>
            GameObject.Instantiate(Resources.Load(GeneralConstants.BombPath),
                GameObject.FindGameObjectWithTag(GeneralConstants.ContainerEnemyTag).transform) as GameObject;

        private void SetMonobehaviorVariables(EcsEntity entity, BombView bombView,
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