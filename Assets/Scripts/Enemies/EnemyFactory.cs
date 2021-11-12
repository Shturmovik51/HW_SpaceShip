using UnityEngine;

namespace SpaceShipGame
{
    public class EnemyFactory
    {
        private Transform _asteroidPref;
        private Asteroid _bigAsteroidModel;
        private Asteroid _normalAsteroidModel;
        private Asteroid _smallAsteroidModel;

        public EnemyFactory(Transform asteroidPref, Asteroid bigAsteroidModel, Asteroid normalAsteroidModel,
                    Asteroid smallAsteroidModel)
        {
            _asteroidPref = asteroidPref;
            _bigAsteroidModel = bigAsteroidModel;
            _normalAsteroidModel = normalAsteroidModel;
            _smallAsteroidModel = smallAsteroidModel;
        }

        public Enemy GetBigAsteroid()
        {
            return Object.Instantiate(_bigAsteroidModel);
        }

        public Enemy GetNormalAsteroid()
        {
            return Object.Instantiate(_normalAsteroidModel);
        }

        public Enemy GetSmallAsteroid()
        {
            return Object.Instantiate(_smallAsteroidModel);
            //return InitAsteroid(_smallAsteroidModel);
        }

        //private Enemy InitAsteroid(AsteroidModelData model)
        //{
        //    var asteroid = Object.Instantiate(_asteroidPref).GetComponent<Asteroid>();
        //    asteroid.transform.localScale = model.Scale;
        //    asteroid.Init(model.Mass, model.Damage, new EntityHealth(model.MaxHealth, model.CurrentHealth));
        //    return asteroid;
        //}
    }
}
