using UnityEngine;

namespace SpaceShipGame
{
    internal class MoveTransform : IMove
    {
        private Rigidbody2D _playerRigidBody;
        private Transform _transform;
        private protected float _speed;
        private float _returningForce = 2f;

        public MoveTransform(Transform transform, Rigidbody2D playerRigidBody, float speed)
        {
            _speed = speed;
            _transform = transform;
            _playerRigidBody = playerRigidBody;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _playerRigidBody.AddForce(Vector2.up * _speed * deltaTime * vertical, ForceMode2D.Impulse);
            _playerRigidBody.AddForce(Vector2.right * _speed * deltaTime * horizontal, ForceMode2D.Impulse);

            //_playerRigidBody.AddForce(_transform.up * _speed * deltaTime * vertical, ForceMode2D.Impulse);
            //_playerRigidBody.AddForce(_transform.right * _speed * deltaTime * horizontal, ForceMode2D.Impulse);
        }

        public void Stop(float fixedDeltaTime)
        {
            _playerRigidBody.velocity = Vector2.zero;
            _playerRigidBody.AddForce((Vector3.zero - _transform.position) * _returningForce * fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
}
