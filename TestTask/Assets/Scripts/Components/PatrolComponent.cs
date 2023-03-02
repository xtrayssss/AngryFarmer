using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct PatrolComponent
    {
        public Transform[] wayPoints;
    }
}