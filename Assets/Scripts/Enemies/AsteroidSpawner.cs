using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipGame
{
    public class AsteroidSpawner : IInitializable, IController
    {
        private EnemyPoolController _enemyPoolController;
        private Transform _leftBorder;
        private Transform _rightBorder;
        private GameStarter _gameStarter;
        private int _spawnTime = 1;
        private float spawnForce = 20;
        public AsteroidSpawner(EnemyPoolController enemyPoolController, Transform leftBorder, Transform rightBorder,
                    GameStarter gameStarter)
        {
            _enemyPoolController = enemyPoolController;
            _leftBorder = leftBorder;
            _rightBorder = rightBorder;
            _gameStarter = gameStarter;
        }

        public void Initialization()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            var spawnposition = new Vector2(Random.Range(_leftBorder.transform.position.x, _rightBorder.transform.position.x),
                                            _leftBorder.transform.position.y);           
            var enemy = _enemyPoolController.GetEnemyFromPool();
            enemy.transform.position = spawnposition;
            enemy.Rigidbody.AddForce(Vector2.down* spawnForce, ForceMode2D.Impulse);
            enemy.Rigidbody.AddTorque(Random.Range(-10f,10f));
            _gameStarter.StartCoroutine(SpawnTimer());
        }

        private IEnumerator SpawnTimer()
        {
            yield return new WaitForSeconds(_spawnTime);
            SpawnEnemy();
        }
    }
}