using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipGame
{
    public class RocketFactory
    {
        private Rocket _ro�ketPref;
        private int _ro�ketDamage;
        private RocketBuilder _ro�ketBuilder;
        
        private float mass = 1f;            // ����� �� ������ �� ��������, ��� ����� �����
        private float scale = 0.2f;

        public RocketFactory(Rocket ro�ketPref, int ro�ketDamage)
        {
            _ro�ketPref = ro�ketPref;
            _ro�ketDamage = ro�ketDamage;
            _ro�ketBuilder = new RocketBuilder();
        }

        public Rocket GetRo�ket()
        {
            // return Rocket.CreateRo�ket(_ro�ketPref, _ro�ketDamage);

            var rocket = _ro�ketBuilder.InstantiateObject()
                                       .AddComponentRocket(_ro�ketDamage)
                                       .AddSprite(Resources.Load<Sprite>("Capsule"))
                                       .AddRigidbody2D(mass)
                                       .AddCapsuleCollider2D()
                                       .Scale(scale)
                                       .ReturnComponentRocket();      //�������������, ����� �� ������������ ���� ���   
            return rocket;
        }
    }
}
