using UnityEngine;

public class PlayerModel
{
    public float Speed { get; set; }
    public float Acceleration { get; }
    public float Hp { get; }
    public Rigidbody2D Bullet { get; }
    public Transform Barrel { get; }
    public float Force { get; }
    public Camera Camera { get; }

    public PlayerModel(float speed, float acceleration, float hp, Rigidbody2D bullet, Transform barrel, float force,
                        Camera camera)
    {
        Speed = speed;
        Acceleration = acceleration;
        Hp = hp;
        Bullet = bullet;
        Barrel = barrel;
        Force = force;
        Camera = camera;
    }
}
