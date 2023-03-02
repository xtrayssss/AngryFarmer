using Leopotam.Ecs;
using Monobehaviors;
using UnityEngine;

namespace Components
{
    internal struct BombComponent
    {
        public GameObject BombObject;

        public BombData BombData;
        public EcsEntity BombEntity;
    }
}