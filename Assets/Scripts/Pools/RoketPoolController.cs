using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipGame
{
    public class RoketPoolController : IInitializable, IController
    {
        private RoketFactory _roketFactory;
        private List<Roket> _roketPool;
        private int _roketsCount = 20;
        private float _roketLifeTime = 10;
        private GameStarter _gameStarter;
        private Transform _roketPoolContainer;

        public RoketPoolController(RoketFactory roketFactory, GameStarter gameStarter)
        {            
            _gameStarter = gameStarter;
            _roketFactory = roketFactory;
            _roketPool = new List<Roket>(_roketsCount);
            _roketPoolContainer = new GameObject(name: "RoketPool").transform;
            _roketPoolContainer.parent = _gameStarter.transform;
        }

        public void Initialization()
        {
            for (int i = 0; i < _roketsCount; i++)
            {
                var roket = _roketFactory.GetRoket();
                roket.gameObject.SetActive(false);
                roket.transform.parent = _roketPoolContainer;
                _roketPool.Add(roket);
            }           
        }

        public Roket GetRoketFromPool()
        {
            var roket = _roketPool[0];
            _roketPool.Remove(roket);
            roket.gameObject.SetActive(true);
            _gameStarter.StartCoroutine(RoketLifeTime(roket));
            return roket;
        }

        public void ReturnRoketToPool(Roket roket)
        {
            roket.gameObject.SetActive(false);
            roket.Rigidbody.velocity = Vector2.zero;
            _roketPool.Add(roket);
        }

        private IEnumerator RoketLifeTime(Roket roket)
        {
            yield return new WaitForSeconds(_roketLifeTime);
            ReturnRoketToPool(roket);
        }
    }
}
