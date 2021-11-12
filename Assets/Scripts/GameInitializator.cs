using UnityEngine;

namespace SpaceShipGame
{
    public sealed class GameInitializator
    {
        public GameInitializator(ControllersManager controllersManager, InputKeysData inputKeysData, PlayerModelData playerData,
                    PlayerView playerView, Camera camera, Transform asteroidPref, AsteroidModelData bigAsteroidModel,
                        AsteroidModelData _normalAsteroidModel, AsteroidModelData _smallAsteroidModel, GameStarter gameStarter,
                            Transform leftBorder, Transform rightBorder, Rocket roñketPref, int roñketDamage, Asteroid bigAsteroid,
                                Asteroid normalAsteroid, Asteroid smallAsteroid)
        {
            var inputController = new InputController(inputKeysData);

            var asteroidFactory = new EnemyFactory(asteroidPref, bigAsteroid, normalAsteroid, smallAsteroid);
            var roñketFactory = new RocketFactory(roñketPref, roñketDamage);

            var enemyPoolController = new EnemyPoolController(asteroidFactory, gameStarter);
            ServiceLocator.SetServiceToDictionary(enemyPoolController);

            var rocketPoolController = new RocketPoolController(roñketFactory, gameStarter);

            var playerModel = new PlayerModel(playerData, camera);
            var playerController = new PlayerController(playerModel, playerView, inputController, rocketPoolController);

            var asteroidSpawner = new AsteroidSpawner(/*enemyPoolController*/leftBorder, rightBorder, gameStarter);

            controllersManager.Add(inputController);
            controllersManager.Add(playerController);
            controllersManager.Add(enemyPoolController);
            controllersManager.Add(rocketPoolController);
            controllersManager.Add(asteroidSpawner);
        }
    }
}
