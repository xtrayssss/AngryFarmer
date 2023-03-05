using UnityEngine;

namespace Monobehaviors
{
    [CreateAssetMenu(fileName = "newBombData", menuName = "Data/BombData")]
    public class BombData : ScriptableObject
    {
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

        public float TimerRespawn;

        public float TimerBombDestroy;
    }
}