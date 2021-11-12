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

        public RocketPoolController(RocketFactory roñketFactory, GameStarter gameStarter)
        {            
            _gameStarter = gameStarter;
            _rocketFactory = roñketFactory;
            _rocketPool = new List<Rocket>(_rocketsCount);
            _rocketPoolContainer = new GameObject(name: "RocketPool").transform;
            _rocketPoolContainer.parent = _gameStarter.transform;
        }

        public void Initialization()
        {
            for (int i = 0; i < _rocketsCount; i++)
            {  
                var rocket = _rocketFactory.GetRoñket();
                rocket.gameObject.SetActive(false);
                rocket.transform.parent = _rocketPoolContainer;
                _rocketPool.Add(rocket);
            }           
        }

        public Rocket GetRoketFromPool()
        {
            var rocket = _rocketPool[0];
            _rocketPool.Remove(rocket);
            rocket.gameObject.SetActive(true);
            _gameStarter.StartCoroutine(RoketLifeTime(rocket));
            return rocket;
        }

        public void ReturnRoketToPool(Rocket rocket)
        {
            rocket.gameObject.SetActive(false);
            rocket.Rigidbody.velocity = Vector2.zero;
            _rocketPool.Add(rocket);
        }

        private IEnumerator RoketLifeTime(Rocket rocket)
        {
            yield return new WaitForSeconds(_rocketLifeTime);
            ReturnRoketToPool(rocket);
        }
    }
}
