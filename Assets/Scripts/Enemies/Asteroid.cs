using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipGame
{
    public class Asteroid : Enemy , IDamagable
    {
        private int _damage;
        public int Damage => _damage;
             
        public void Init(float mass, int damage, EntityHealth health)
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.mass = mass;
            _damage = damage;
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            var health = Health.Current - damage;

            if(health <= 0)
            {
                health = 0;
                gameObject.SetActive(false);
            }

            Health.ChangeCurrentHealth(health);
            Debug.Log($"Enemy HP = {Health.Current}");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out IDamagable collObject))
            {
                collObject.TakeDamage(_damage);
            }
        }
    }
}