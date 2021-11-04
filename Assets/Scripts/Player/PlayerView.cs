using System;
using UnityEngine;

namespace SpaceShipGame
{
    public class PlayerView : MonoBehaviour, IMove, IRotation, IDamagable
    {
        [SerializeField] private Transform _shootStartPosition;

        public event Action<int> OnTakeDamage;

        private IMove _moveImplementation;
        private IRotation _rotationImplementation;

        public void Init(float speed, float acceleration)
        {
            var playerRigidBody = GetComponent<Rigidbody2D>();
            _moveImplementation = new AccelerationMove(transform, playerRigidBody, speed, acceleration);
            _rotationImplementation = new RotationShip(transform);
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public void Shoot(Roket roket, float force)
        {
            roket.gameObject.SetActive(true);
            roket.transform.position = _shootStartPosition.position;
            roket.Rigidbody.AddForce(Vector3.up * force, ForceMode2D.Impulse);
        }

        public void TakeDamage(int damage)
        {
            OnTakeDamage?.Invoke(damage);
        }
    }
}