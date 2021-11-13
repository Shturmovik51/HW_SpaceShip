using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipGame
{
    public class RocketFactory
    {
        private Rocket _rocketPref;
        private int _rocketDamage;
        private RocketBuilder _rocketBuilder;
        
        private float mass = 1f;            // чтобы не тянуть со стартера, все равно удалю
        private float scale = 0.2f;

        public RocketFactory(Rocket rocketPref, int rocketDamage)
        {
            _rocketPref = rocketPref;
            _rocketDamage = rocketDamage;
            _rocketBuilder = new RocketBuilder();
        }

        public Rocket GetRocket()
        {
            // return Rocket.CreateRocket(_rocketPref, _rocketDamage);

            var rocket = _rocketBuilder.InstantiateObject()
                                       .AddComponentRocket(_rocketDamage)
                                       .AddSprite(Resources.Load<Sprite>("Capsule"))
                                       .AddRigidbody2D(mass)
                                       .AddCapsuleCollider2D()
                                       .Scale(scale)
                                       .ReturnComponentRocket();      //необходимость, чтобы не переписывать весь пул   
            return rocket;
        }
    }
}
