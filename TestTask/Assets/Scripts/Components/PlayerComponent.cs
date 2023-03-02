using Monobehaviors;
using UnityEngine;

namespace Components
{
    internal struct PlayerComponent
    {
        public Rigidbody2D Rigidbody;
        public Collider2D Collider2D;
        public Transform Transform;
        public PlayerData PlayerData;
    }
}