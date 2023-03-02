using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    internal struct SpawnObjectComponent
    {
        public List<GameObject> PoolObjects;

        public float CoolDownSpawn;

        public float TimerSpawn;
    }
}