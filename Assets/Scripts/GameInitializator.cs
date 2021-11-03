using UnityEngine;

namespace SpaceShipGame
{
    public sealed class GameInitializator
    {
        public GameInitializator(ControllersManager controllersManager, InputKeysData inputKeysData, PlayerModelData playerData,
                    PlayerView playerView, Camera camera)
        {
            var inputController = new InputController(inputKeysData);

            var playerModel = new PlayerModel(playerData, camera);
            var playerController = new PlayerController(playerModel, playerView, inputController);

            controllersManager.Add(inputController);
            controllersManager.Add(playerController);
        }
    }
}
