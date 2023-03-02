using UnityEngine;

namespace Monobehaviors
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [Header("Speeds")] public float speed;

        [Header("Health")] [SerializeField] private int _maxHealth;

        [SerializeField] private int[] _damagesEntity;

        private float _health;
        public int MAXHealth => _maxHealth;

        public int[] DamagesEntity
        {
            get => _damagesEntity;
            set => _damagesEntity = value;
        }

        public float Health
        {
            get => _health;
            set => _health = value;
        }
    }
}