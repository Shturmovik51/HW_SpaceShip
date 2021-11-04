using UnityEngine;

namespace SpaceShipGame
{
    public abstract class Enemy : MonoBehaviour
    {
        public EntityHealth Health { get; set; }
        public Rigidbody2D Rigidbody { get; set; }
    }
}