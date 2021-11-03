using System;
using UnityEngine;

namespace SpaceShipGame
{
    public sealed class InputKeys
    {
        public void GetKeyShoot(InputKeysData _inputKeysData, Action action)
        {
            if (Input.GetKey(_inputKeysData.Shoot)) action?.Invoke();
        }
        public void GetKeyAxelerationDown(InputKeysData _inputKeysData, Action action)
        {
            if (Input.GetKeyDown(_inputKeysData.Axeleration)) action?.Invoke();
        }
        public void GetKeyAxelerationUp(InputKeysData _inputKeysData, Action action)
        {
            if (Input.GetKeyUp(_inputKeysData.Axeleration)) action?.Invoke();
        }
    }
}
