using Interfaces;
using UnityEngine;

namespace Components
{
    internal struct AnimationComponentEnemy : IAnimationComponent
    {
        public bool IsAgro;
        public Animator Animator { get; set; }
    }
}