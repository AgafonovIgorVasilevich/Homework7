using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private TargetPoint[] _targetPoints;
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

        while (currentCount < _maxCount)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            TargetPoint targetPoint = _targetPoints[Random.Range(0, _targetPoints.Length)];
            Enemy enemy = Instantiate(_enemy);

            enemy.transform.position = spawnPoint.position;
            enemy.SetDirection(targetPoint.GetPosition());
            currentCount++;

            yield return delay;
        }
    }
}