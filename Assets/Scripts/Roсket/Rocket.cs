using UnityEngine;

namespace SpaceShipGame
{
    public class Rocket : MonoBehaviour
    {
        private int _damage;
        private Rigidbody2D _rigidbody;
        public int Damage => _damage;
        public Rigidbody2D Rigidbody => _rigidbody;

        public void InitDamage(int damage)
        {
            _damage = damage;
        }

        public void InitRigidbody(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }
        //public static Rocket CreateRocket(Rocket rocketPref, int damage)
        //{
        //    var roñket = Instantiate(roketPref);
        //    roñket.Init(damage);
        //    return rocket;
        //}
        //public void Init(int damage)
        //{
        //    _rigidbody = GetComponent<Rigidbody2D>();
        //    _damage = damage;
        //}

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