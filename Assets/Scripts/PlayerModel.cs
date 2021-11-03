using UnityEngine;

namespace SpaceShipGame
{
    public class PlayerModel
    {
        public float Speed { get; set; }
        public float Axeleration { get; }
        public float Hp { get; }
        public float Force { get; }
        public Camera Camera { get; }

        public PlayerModel(PlayerModelData playerData, Camera camera)
        {
            Speed = playerData.Speed;
            Axeleration = playerData.Axeleration;
            Hp = playerData.HP;
            Force = playerData.Force;
            Camera = camera;
        }
    }
}