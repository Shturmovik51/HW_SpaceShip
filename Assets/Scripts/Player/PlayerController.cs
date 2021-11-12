using System.Collections;
using UnityEngine;

namespace SpaceShipGame
{
    public class PlayerController : IInitializable, IFixedUpdatable, ICleanable, IController
    {
        private PlayerModel _playerModel;
        private PlayerView _playerView;
        private InputController _inputController;
        private RocketPoolController _roketPool;
        private bool _isCanShoot;

        public PlayerController(PlayerModel playerModel, PlayerView playerView, InputController inputController, 
                    RocketPoolController roketPool)
        {
            _playerModel = playerModel;
            _playerView = playerView;
            _inputController = inputController;
            _roketPool = roketPool;
        }

        public void Initialization()
        {
            _inputController.OnClickAxelerationDown += AddPlayerAcceleration;
            _inputController.OnClickAxelerationUp += RemovePlayerAcceleration;
            _inputController.OnInputMoveAxis += PlayerMove;
            _inputController.OnInputMousePosition += PlayerRotation;
            _inputController.OnClickShootButton += PlayerShoot;
            _playerView.OnTakeDamage += GetDamage;

            _playerView.Init(_playerModel.Speed, _playerModel.Axeleration);
            _isCanShoot = true;
        }
        public void CleanUp()
        {
            _inputController.OnClickAxelerationDown -= AddPlayerAcceleration;
            _inputController.OnClickAxelerationUp -= RemovePlayerAcceleration;
            _inputController.OnInputMoveAxis -= PlayerMove;
            _inputController.OnInputMousePosition -= PlayerRotation;
            _inputController.OnClickShootButton -= PlayerShoot;
            _playerView.OnTakeDamage -= GetDamage;
        }

        public void PlayerMove(float horizontal, float vertical, float deltaTime)
        {
            _playerView.Move(horizontal, vertical, deltaTime);
        }

        public void PlayerRotation(Vector3 mousePosition)
        {
            var direction = Camera.main.ScreenToWorldPoint(mousePosition) - _playerView.transform.position;
            direction.z = _playerView.transform.position.z;
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
            PlayerInViewController(fixedDeltatime);
        }        

        private void GetDamage(int damage)
        {
            _playerModel.Hp -= damage;
            Debug.Log($"Player HP = { _playerModel.Hp}");
        }

        private void PlayerShoot()
        {
            if (!_isCanShoot) return;

            _isCanShoot = false;
            var roket = _roketPool.GetRoketFromPool();
            _playerView.Shoot(roket, _playerModel.Force);
            _playerView.StartCoroutine(ShootDelay());

        }

        private IEnumerator ShootDelay()
        {
            yield return new WaitForSeconds(1);
            _isCanShoot = true;
        }

        private void PlayerInViewController(float fixedDeltaTime)
        {
            Vector2 playerScreenPosition = Camera.main.WorldToScreenPoint(_playerView.transform.position);
            if ((playerScreenPosition.y > Screen.height) || (playerScreenPosition.y < 0f) ||
                (playerScreenPosition.x > Screen.width) || (playerScreenPosition.x < 0f))
            {
                _playerView.Stop(fixedDeltaTime);
            }
        }
    }
}
