using Leopotam.Ecs;
using UnityEngine;

namespace Monobehaviors
{
    public class EnemyView : MonoBehaviour
    {
        public EcsEntity Entity;

        public EnemyData EnemyData;
        
        public bool allowPatrolling;
    }
}