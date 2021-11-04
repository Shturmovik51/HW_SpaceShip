using UnityEngine;

namespace SpaceShipGame
{
    [CreateAssetMenu(menuName = "DataBase/AsteroidModelData", fileName = nameof(AsteroidModelData))]
    public sealed class AsteroidModelData : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _mass;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _currentHealth;
        [SerializeField] private Vector3 _scale;
        public int Damage => _damage;
        public float Mass => _mass;
        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;
        public Vector3 Scale => _scale;
    }
}
