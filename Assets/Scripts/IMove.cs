namespace SpaceShipGame
{
    public interface IMove
    {
        void Move(float horizontal, float vertical, float deltaTime);
        void Stop(float fixedDeltatime);
    }
}