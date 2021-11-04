namespace SpaceShipGame
{
    public sealed class EntityHealth
    {
        public float Max { get; }
        public float Current { get; set; }

        public EntityHealth(float max, float current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }
    }
}
