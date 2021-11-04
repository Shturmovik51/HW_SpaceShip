using UnityEngine;

namespace SpaceShipGame
{
    public sealed class GameInitializator
    {
        public GameInitializator(ControllersManager controllersManager, InputKeysData inputKeysData, PlayerModelData playerData,
                    PlayerView playerView, Camera camera, Transform asteroidPref, AsteroidModelData bigAsteroidModel,
                        AsteroidModelData _normalAsteroidModel, AsteroidModelData _smallAsteroidModel, GameStarter gameStarter,
                            Transform leftBorder, Transform rightBorder, Roket roketPref, int roketDamage)
        {
            var inputController = new InputController(inputKeysData);

            var asteroidFactory = new EnemyFactory(asteroidPref, bigAsteroidModel, _normalAsteroidModel, _smallAsteroidModel);
            var roketFactory = new RoketFactory(roketPref, roketDamage);

            var enemyPoolController = new EnemyPoolController(asteroidFactory, gameStarter);
            var roketPoolController = new RoketPoolController(roketFactory, gameStarter);

            var playerModel = new PlayerModel(playerData, camera);
            var playerController = new PlayerController(playerModel, playerView, inputController, roketPoolController);

            var asteroidSpawner = new AsteroidSpawner(enemyPoolController, leftBorder, rightBorder, gameStarter);

            controllersManager.Add(inputController);
            controllersManager.Add(playerController);
            controllersManager.Add(enemyPoolController);
            controllersManager.Add(roketPoolController);
            controllersManager.Add(asteroidSpawner);
        }
    }
}
