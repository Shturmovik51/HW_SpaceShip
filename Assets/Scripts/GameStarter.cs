using UnityEngine;

namespace SpaceShipGame
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Rocket _rocketPref;
        [SerializeField] private Transform _asteroidPref;
        [SerializeField] private AsteroidModelData _bigAsteroidModel;
        [SerializeField] private AsteroidModelData _normalAsteroidModel;
        [SerializeField] private AsteroidModelData _smallaAsteroidModel;

        [SerializeField] private Asteroid _bigAsteroidPrototype;
        [SerializeField] private Asteroid _normalAsteroidPrototype;
        [SerializeField] private Asteroid _smallAsteroidPrototype;

        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private int _rocketDamage;

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

            new GameInitializator(_controllersManager, _inputKeysData, _playerModelData, _playerView, _camera, _asteroidPref,
                     _bigAsteroidModel, _normalAsteroidModel, _smallaAsteroidModel, this, _leftBorder, _rightBorder, _rocketPref,
                        _rocketDamage, _bigAsteroidPrototype, _normalAsteroidPrototype, _smallAsteroidPrototype);

            _controllersManager.Initialization();           
        }

        private void Update()
        {
            _controllersManager.LocalUpdate(Time.deltaTime);
        }
        private void FixedUpdate()
        {
            _controllersManager.LocalFixedUpdate(Time.fixedDeltaTime);
        }

    }
}