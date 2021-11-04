using UnityEngine;

namespace SpaceShipGame
{
    public class Roket : MonoBehaviour
    {
        private int _damage;
        private Rigidbody2D _rigidbody;
        public int Damage => _damage;
        public Rigidbody2D Rigidbody => _rigidbody;

        public static Roket CreateRoket(Roket roketPref, int damage)
        {
            var roket = Instantiate(roketPref);
            roket.Init(damage);
            return roket;
        }
        public void Init(int damage)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamagable collObject))
            {
                collObject.TakeDamage(_damage);
            }
            gameObject.SetActive(false);
        }
    }
}