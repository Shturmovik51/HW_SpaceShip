using UnityEngine;

namespace SpaceShipGame
{
    internal sealed class RotationShip : IRotation
    {
        private readonly Transform _transform;

        public RotationShip(Transform transform)
        {
            _transform = transform;
        }

        public void Rotation(Vector3 direction)
        {
            _transform.up = direction;
        }
    }
}
