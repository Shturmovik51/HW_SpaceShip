using UnityEngine;

namespace SpaceShipGame
{
    public class GameStarter : MonoBehaviour
    {        
        [SerializeField] private PlayerView _playerView;

        private Camera _camera;
        private ControllersManager _controllersManager;
        private InputKeysData _inputKeysData;
        private PlayerModelData _playerModelData;

        private void Start()
        {
            _camera = Camera.main;
            _inputKeysData = (InputKeysData)Resources.Load("InputKeysData");
            _playerModelData = (PlayerModelData)Resources.Load("PlayerModelData");

            _controllersManager = new ControllersManager();

            new GameInitializator(_controllersManager, _inputKeysData, _playerModelData, _playerView, _camera);

            _controllersManager.Initialization();           
        }

        private void Update()
        {
            _controllersManager.LocalLateUpdate(Time.deltaTime);

            ////var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);

            //if (Input.GetButtonDown("Fire1"))
            //{
            //    var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
            //    temAmmunition.AddForce(_barrel.up * _force);
            //}
        }
        private void FixedUpdate()
        {
            _controllersManager.LocalFixedUpdate(Time.fixedDeltaTime);
        }

    }
}