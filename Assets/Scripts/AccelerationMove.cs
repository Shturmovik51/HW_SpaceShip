using UnityEngine;

namespace SpaceShipGame
{
    internal sealed class AccelerationMove : MoveTransform
    {
        private readonly float _acceleration;

        public AccelerationMove(Transform transform, Rigidbody2D playerRigidBody, float speed, float acceleration) :
                                    base(transform, playerRigidBody, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            _speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            _speed -= _acceleration;
        }
    }
}