using UnityEngine;

namespace SpaceShipGame
{
    [CreateAssetMenu(menuName = "DataBase/InputKeysData", fileName = nameof(InputKeysData))]
    public sealed class InputKeysData : ScriptableObject
    {
        [SerializeField] private KeyCode _shoot;
        [SerializeField] private KeyCode _axeleration;
        public KeyCode Shoot => _shoot;
        public KeyCode Axeleration => _axeleration;
    }
}