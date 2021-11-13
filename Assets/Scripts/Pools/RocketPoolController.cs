using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipGame
{
    public class RocketPoolController : IInitializable, IController
    {
        private RocketFactory _rocketFactory;
        private List<Rocket> _rocketPool;
        private int _rocketsCount = 20;
        private float _rocketLifeTime = 10;
        private GameStarter _gameStarter;
        private Transform _rocketPoolContainer;       

        public RocketPoolController(RocketFactory rocketFactory, GameStarter gameStarter)
        {            
            _gameStarter = gameStarter;
            _rocketFactory = rocketFactory;
            _rocketPool = new List<Rocket>(_rocketsCount);
            _rocketPoolContainer = new GameObject(name: "RocketPool").transform;
            _rocketPoolContainer.parent = _gameStarter.transform;
        }

        public void Initialization()
        {
            for (int i = 0; i < _rocketsCount; i++)
            {  
                var rocket = _rocketFactory.GetRocket();
                rocket.gameObject.SetActive(false);
                rocket.transform.parent = _rocketPoolContainer;
                _rocketPool.Add(rocket);
            }           
        }

        public Rocket GetRocketFromPool()
        {
            var rocket = _rocketPool[0];
            _rocketPool.Remove(rocket);
            rocket.gameObject.SetActive(true);
            _gameStarter.StartCoroutine(RocketLifeTime(rocket));
            return rocket;
        }

        public void ReturnRocketToPool(Rocket rocket)
        {
            rocket.gameObject.SetActive(false);
            rocket.Rigidbody.velocity = Vector2.zero;
            _rocketPool.Add(rocket);
        }

        private IEnumerator RocketLifeTime(Rocket rocket)
        {
            yield return new WaitForSeconds(_rocketLifeTime);
            ReturnRocketToPool(rocket);
        }
    }
}
