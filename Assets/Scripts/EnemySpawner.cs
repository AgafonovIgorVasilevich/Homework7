using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private TargetPoint[] _targetPoints;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _delay = 2f;
    [SerializeField] private int _maxCount = 100;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int currentCount = 0;

        while (currentCount < _maxCount)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            TargetPoint targetPoint = _targetPoints[Random.Range(0, _targetPoints.Length)];
            GameObject enemy = Instantiate(_enemy);

            enemy.transform.position = spawnPoint.position;
            enemy.GetComponent<EnemyMovement>().TargetPoint = targetPoint;
            currentCount++;

            yield return new WaitForSeconds(_delay);
        }
    }
}