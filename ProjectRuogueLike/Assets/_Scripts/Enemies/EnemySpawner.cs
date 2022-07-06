using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab = null;
    [SerializeField]
    private List<GameObject> _spawnPoints = null;
    [SerializeField]
    private int _count = 20;
    [SerializeField]
    private float _minDelay = 0.8f, _maxDelay = 1.5f;

    IEnumerator SpawnCoroutine()
    {
        while (_count > 0)
        {
            _count--;
            var randomIndex = Random.Range(0, _spawnPoints.Count);

            var randomOffset = Random.insideUnitCircle;
            var spawnPoint = _spawnPoints[randomIndex].transform.position + (Vector3)randomOffset;

            SpawnEnemy(spawnPoint);

            var randomTime = Random.Range(_minDelay, _maxDelay);

            yield return new WaitForSeconds(randomTime);

        }
    }

    private void SpawnEnemy(Vector3 spawnPoint)
    {
        Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity);
    }

    private void Start()
    {
        if (_spawnPoints.Count > 0)
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                SpawnEnemy(spawnPoint.transform.position);
            }
        }
        StartCoroutine(SpawnCoroutine());
    }
}
