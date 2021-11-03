using System;
using UnityEngine;

namespace SpaceShipGame
{
    public sealed class InputController : IUpdatable, IController
    {
        public event Action OnClickShootButton;
        public event Action OnClickAxelerationDown;
        public event Action OnClickAxelerationUp;
        public event Action<float, float, float> OnInputMoveAxis = delegate { };

        private readonly InputKeys _inputKeys;
        private readonly InputAxis _inputAxis;
        private readonly InputKeysData _inputKeysData;

        public InputController(InputKeysData inputKeysData)
        {
            _inputKeys = new InputKeys();
            _inputAxis = new InputAxis();
            _inputKeysData = inputKeysData;
        }

        public void LocalUpdate(float deltaTime)
        {
            Debug.Log("Da");

            if (Time.timeScale == Mathf.Round(0)) return;
            OnInputMoveAxis.Invoke(_inputAxis.GetMoveAxis().horizontal, _inputAxis.GetMoveAxis().vertical, deltaTime);
            _inputKeys.GetKeyShoot(_inputKeysData, OnClickShootButton);
            _inputKeys.GetKeyAxelerationDown(_inputKeysData, OnClickAxelerationDown);
            _inputKeys.GetKeyAxelerationUp(_inputKeysData, OnClickAxelerationUp);
        }        
    }
}
