using Interfaces;
using UnityEngine;

namespace Components
{
    internal struct AnimationComponentPlayer : IAnimationComponent
    {
        public Animator Animator { get; set; }
    }
}