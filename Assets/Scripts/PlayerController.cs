using UnityEngine;

public class PlayerController
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private Rigidbody2D _playerRigidBody;

    public PlayerController(PlayerModel playerModel, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerView = playerView;
        _playerRigidBody = playerView.GetComponent<Rigidbody2D>();
    }

    public void InitView()
    {
        _playerView.Init(_playerModel.Speed, _playerModel.Acceleration, _playerRigidBody);
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

}

