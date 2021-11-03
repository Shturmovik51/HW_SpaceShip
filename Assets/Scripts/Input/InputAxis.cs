using System;
using UnityEngine;

namespace SpaceShipGame
{
    public class InputAxis
    {
        public (float horizontal, float vertical) GetMoveAxis()
        {
            return (Input.GetAxis(AxisManager.Horizontal), Input.GetAxis(AxisManager.Vertical));
        }        
    }
}