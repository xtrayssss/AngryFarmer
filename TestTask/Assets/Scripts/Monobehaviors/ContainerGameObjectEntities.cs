using System.Collections.Generic;
using UnityEngine;

namespace Monobehaviors
{
    internal class ContainerGameObjectEntities : MonoBehaviour
    {
        [HideInInspector] public List<GameObject> EnemyPoolObjects;
        
        [HideInInspector] public List<GameObject> BombPoolObjecs;
    }
}