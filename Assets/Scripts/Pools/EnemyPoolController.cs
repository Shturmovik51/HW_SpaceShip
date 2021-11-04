using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipGame
{
    public class EnemyPoolController : IInitializable, IController
    {
        private EnemyFactory _enemyFactory;
        private List<Enemy> _enemyPool;
        private int _bigAsteroidsCount = 10;
        private int _normalAsteroidsCount = 30;
        private int _smallAsteroidsCount = 30;
        private int _enemyLifeTime = 20;
        private GameStarter _gameStarter;
        private Transform _enemyPoolContainer;

        public EnemyPoolController(EnemyFactory enemyFactory, GameStarter gameStarter)
        {
            _enemyFactory = enemyFactory;
            _enemyPool = new List<Enemy>(_bigAsteroidsCount + _normalAsteroidsCount + _smallAsteroidsCount);
            _gameStarter = gameStarter;            
            _enemyPoolContainer = new GameObject(name: "EnemyPool").transform;
            _enemyPoolContainer.parent = _gameStarter.transform;
        }

        public void Initialization()
        {
            for (int i = 0; i < _bigAsteroidsCount; i++)
            {
                var enemy = _enemyFactory.GetBigAsteroid();
                enemy.gameObject.SetActive(false);
                enemy.transform.parent = _enemyPoolContainer;
                _enemyPool.Add(enemy);
            }

            for (int i = 0; i < _normalAsteroidsCount; i++)
            {
                var enemy = _enemyFactory.GetNormalAsteroid();
                enemy.gameObject.SetActive(false);
                enemy.transform.parent = _enemyPoolContainer;
                _enemyPool.Add(enemy);
            }

            for (int i = 0; i < _smallAsteroidsCount; i++)
            {
                var enemy = _enemyFactory.GetSmallAsteroid();
                enemy.gameObject.SetActive(false);
                enemy.transform.parent = _enemyPoolContainer;
                _enemyPool.Add(enemy);
            }
        } 

        public Enemy GetEnemyFromPool()
        {
            var enemy = _enemyPool[Random.Range(0, _enemyPool.Count-1)];
            _enemyPool.Remove(enemy);
            enemy.gameObject.SetActive(true);
            _gameStarter.StartCoroutine(EnemyLifeTime(enemy));
            return enemy;
        }

        public void ReturnEnemyToPool(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.Rigidbody.velocity = Vector2.zero;
            enemy.Health.Current = enemy.Health.Max;
            _enemyPool.Add(enemy);
        }

        private IEnumerator EnemyLifeTime(Enemy enemy)
        {
            yield return new WaitForSeconds(_enemyLifeTime);
            ReturnEnemyToPool(enemy);
        }
    }
}