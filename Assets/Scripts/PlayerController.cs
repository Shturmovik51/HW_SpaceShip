using UnityEngine;

namespace SpaceShipGame
{
    public class PlayerController : IInitializable, IFixedUpdatable, ICleanable, IController
    {
        private PlayerModel _playerModel;
        private PlayerView _playerView;
        private InputController _inputController;

        public PlayerController(PlayerModel playerModel, PlayerView playerView, InputController inputController)
        {
            _playerModel = playerModel;
            _playerView = playerView;
            _inputController = inputController;
        }

        public void Initialization()
        {
            _inputController.OnClickAxelerationDown += AddPlayerAcceleration;
            _inputController.OnClickAxelerationUp += RemovePlayerAcceleration;
            _inputController.OnInputMoveAxis += PlayerMove;

            _playerView.Init(_playerModel.Speed, _playerModel.Axeleration);
        }
        public void CleanUp()
        {
            _inputController.OnClickAxelerationDown -= AddPlayerAcceleration;
            _inputController.OnClickAxelerationUp -= RemovePlayerAcceleration;
            _inputController.OnInputMoveAxis -= PlayerMove;
        }

        public void PlayerMove(float horizontal, float vertical, float deltaTime)
        {
            _playerView.Move(horizontal, vertical, deltaTime);
        }

        public void PlayerRotation(Vector3 direction)
        {
            _playerView.Rotation(direction);
        }

        public void AddPlayerAcceleration()
        {
            _playerView.AddAcceleration();
        }

        public void RemovePlayerAcceleration()
        {
            _playerView.RemoveAcceleration();
        }

        public void LocalFixedUpdate(float fixedDeltatime)
        {
            
        }        
    }
}
