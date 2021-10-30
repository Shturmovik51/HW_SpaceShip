using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _hp;
    [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private Transform _barrel;
    [SerializeField] private float _force;
    private Camera _camera;

    private PlayerController _playerController;
    [SerializeField] private PlayerView _playerView;

    private void Start()
    {
        _camera = Camera.main;
        
        var playerModel = new PlayerModel(_speed, _acceleration, _hp, _bullet, _barrel, _force, _camera);
        _playerController = new PlayerController(playerModel, _playerView);
        _playerController.InitView();
    }

    private void Update()
    {
        var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);

        _playerController.PlayerRotation(direction);

        _playerController.PlayerMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _playerController.AddPlayerAcceleration();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _playerController.RemovePlayerAcceleration();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
        }
    }

}
