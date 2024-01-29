using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delayTime = 2f;
    [SerializeField] private int _maxCount = 100;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayTime);
        int currentCount = 0;
        Vector3 spawnPoint;
        Vector3 targetPoint;

        while (currentCount < _maxCount)
        {
            Enemy enemy = Instantiate(_enemy);

            spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            targetPoint = _targetPoints[Random.Range(0, _targetPoints.Length)].position;

            enemy.transform.position = spawnPoint;
            enemy.transform.LookAt(targetPoint);

            currentCount++;

            yield return delay;
        }
    }
}