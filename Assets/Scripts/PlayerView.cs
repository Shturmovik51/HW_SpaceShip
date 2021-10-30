using UnityEngine;

public class PlayerView : MonoBehaviour, IMove, IRotation
{
    private  IMove _moveImplementation;
    private  IRotation _rotationImplementation;

    public void Init(float speed, float acceleration, Rigidbody2D playerRigidBody)
    {
        _moveImplementation = new AccelerationMove(transform, playerRigidBody, speed, acceleration);
        _rotationImplementation = new RotationShip(transform);
    }

    public void Move(float horizontal, float vertical, float deltaTime)
    {
        _moveImplementation.Move(horizontal, vertical, deltaTime);
    }

    public void Rotation(Vector3 direction)
    {
        _rotationImplementation.Rotation(direction);
    }

    public void AddAcceleration()
    {
        if (_moveImplementation is AccelerationMove accelerationMove)
        {
            accelerationMove.AddAcceleration();
        }
    }

    public void RemoveAcceleration()
    {
        if (_moveImplementation is AccelerationMove accelerationMove)
        {
            accelerationMove.RemoveAcceleration();
        }
    }
}
