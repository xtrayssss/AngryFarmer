using Monobehaviors;
using UnityEngine;

namespace Components
{
    public struct EnemyComponent
    {
        public Rigidbody2D Rigidbody;
        public Collider2D Collider2D;
        public Transform Transform;
        public Transform[] WayPoints;
        public int IndexWayPoint;
        public EnemyData EnemyData;
    }
}