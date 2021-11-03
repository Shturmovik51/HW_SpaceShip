using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipGame
{
    public abstract class Enemy : MonoBehaviour
    {
        public EntityHealth Health { get; private set; }
    }
}