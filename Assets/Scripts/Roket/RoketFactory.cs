using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipGame
{
    public class RoketFactory
    {
        private Roket _roketPref;
        private int _roketDamage; 
        public RoketFactory(Roket roketPref, int roketDamage)
        {
            _roketPref = roketPref;
            _roketDamage = roketDamage;
        }

        public Roket GetRoket()
        {
            return Roket.CreateRoket(_roketPref, _roketDamage);
        }
    }
}
