using UnityEngine;

namespace SpaceShipGame
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _health;
        [SerializeField] protected int _damage;
        [SerializeField] protected Rigidbody2D _rigidbody;
        public EntityHealth Health;


        public int Damage => _damage;
        public Rigidbody2D Rigidbody => _rigidbody;

        public Enemy()
        {
            Health = new EntityHealth(_health, _health);
        }

        //public EntityHealth Health { get; set; }
        //public Rigidbody2D Rigidbody { get; set; }
        //public int Damage { get; protected set; }
    }
}