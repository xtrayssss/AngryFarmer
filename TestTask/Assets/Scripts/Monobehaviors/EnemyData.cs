using UnityEngine;
using UnityEngine.Serialization;

namespace Monobehaviors
{
    [CreateAssetMenu(fileName = "newEntityData", menuName = "Data/EntityData")]
    public class EnemyData : ScriptableObject
    {
        [Header("Speeds")] public float DefaultSpeed;

        [SerializeField] private float _agroSpeed;

        [Header("Health")] [SerializeField] private int _maxHealth;

        [SerializeField] private int _damage;

        public float AgroSpeed
        {
            get => _agroSpeed;
            set => _agroSpeed = value;
        }

        public int[] DamagesEntity;

        public int Damage => _damage;
        public int MAXHealth => _maxHealth;
    }
}