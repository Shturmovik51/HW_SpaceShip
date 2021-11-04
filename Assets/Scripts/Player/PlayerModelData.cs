using UnityEngine;

namespace SpaceShipGame
{
    [CreateAssetMenu(menuName = "DataBase/PlayerModelData", fileName = nameof(PlayerModelData))]
    public sealed class PlayerModelData : ScriptableObject
    {
        [SerializeField] private int _hP;
        [SerializeField] private float _speed;
        [SerializeField] private float _axeleration;
        [SerializeField] private float _force;

        public int HP => _hP;
        public float Speed => _speed;
        public float Axeleration => _axeleration;
        public float Force => _force;
    }
}
