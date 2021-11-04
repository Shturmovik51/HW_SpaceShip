using UnityEngine;

namespace SpaceShipGame
{
    public class EnemyFactory
    {
        private Transform _asteroidPref;
        private AsteroidModelData _bigAsteroidModel;
        private AsteroidModelData _normalAsteroidModel;
        private AsteroidModelData _smallAsteroidModel;

        public EnemyFactory(Transform asteroidPref, AsteroidModelData bigAsteroidModel, AsteroidModelData normalAsteroidModel,
                    AsteroidModelData smallAsteroidModel)
        {
            _asteroidPref = asteroidPref;
            _bigAsteroidModel = bigAsteroidModel;
            _normalAsteroidModel = normalAsteroidModel;
            _smallAsteroidModel = smallAsteroidModel;
        }

        public Enemy GetBigAsteroid()
        {
            return InitAsteroid(_bigAsteroidModel);
        }

        public Enemy GetNormalAsteroid()
        {
            return InitAsteroid(_normalAsteroidModel);
        }

        public Enemy GetSmallAsteroid()
        {
            return InitAsteroid(_smallAsteroidModel);
        }

        private Enemy InitAsteroid(AsteroidModelData model)
        {
            var asteroid = Object.Instantiate(_asteroidPref).GetComponent<Asteroid>();
            asteroid.transform.localScale = model.Scale;
            asteroid.Init(model.Mass, model.Damage, new EntityHealth(model.MaxHealth, model.CurrentHealth));
            return asteroid;
        }
    }
}
