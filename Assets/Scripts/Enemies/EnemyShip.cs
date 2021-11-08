using UnityEngine;

namespace SpaceShipGame
{
    public class EnemyShip : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private int _axeleration;
        [SerializeField] private int _speed;

        private void LateUpdate()
        {
            transform.up = _target.position - transform.position;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(transform.up * _axeleration * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
}