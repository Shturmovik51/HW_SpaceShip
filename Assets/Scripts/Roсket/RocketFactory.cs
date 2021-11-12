using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipGame
{
    public class RocketFactory
    {
        private Rocket _roñketPref;
        private int _roñketDamage;
        private RocketBuilder _roñketBuilder;
        
        private float mass = 1f;            // ÷òîáû íå òÿíóòü ñî ñòàğòåğà, âñå ğàâíî óäàëş
        private float scale = 0.2f;

        public RocketFactory(Rocket roñketPref, int roñketDamage)
        {
            _roñketPref = roñketPref;
            _roñketDamage = roñketDamage;
            _roñketBuilder = new RocketBuilder();
        }

        public Rocket GetRoñket()
        {
            // return Rocket.CreateRoñket(_roñketPref, _roñketDamage);

            var rocket = _roñketBuilder.InstantiateObject()
                                       .AddComponentRocket(_roñketDamage)
                                       .AddSprite(Resources.Load<Sprite>("Capsule"))
                                       .AddRigidbody2D(mass)
                                       .AddCapsuleCollider2D()
                                       .Scale(scale)
                                       .ReturnComponentRocket();      //íåîáõîäèìîñòü, ÷òîáû íå ïåğåïèñûâàòü âåñü ïóë   
            return rocket;
        }
    }
}
