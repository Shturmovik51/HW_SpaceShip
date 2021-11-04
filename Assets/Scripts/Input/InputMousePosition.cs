using UnityEngine;

namespace SpaceShipGame
{
    public class InputMousePosition
    {
        public Vector3 GetMousePosition()
        {
            var mousePos = Input.mousePosition;
            return mousePos;
        }
    }
}