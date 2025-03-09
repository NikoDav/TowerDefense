using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveController : MonoBehaviour
{
    [SerializeField] private List<MapConfigure> _maps;
    private GameObject _map;
    private List<Transform> _spawnPoints;
    private List<WaveConfigure> _waves;
    private int _currentMapIndex = 0;
    private int _currentWaveIndex = 0;

    private void Start()
    {
        InnitMap(_currentMapIndex);
    }

    private void InnitMap(int index)
    {
        if(_map != null)
        {
            _map.SetActive(false);
        }
        _map = _maps[index].Map;
        _spawnPoints = _maps[index].SpawnPoints;
        _waves = _maps[index].Waves;

        _currentWaveIndex = 0;

        _map.SetActive(true);
    }

    public void SpawnEnemies()
    {
        int enemiesAmount = _waves[_currentWaveIndex].EnemiesAmount;
        List<Enemy> enemies = _waves[_currentWaveIndex].Enemies;

        for (int i = 0; i < enemiesAmount; i++)
        {
            Enemy newEnemy = enemies[UnityEngine.Random.Range(0, _waves[_currentWaveIndex].Enemies.Count)];
            Vector3 randomSpawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].transform.position;

            Instantiate(newEnemy, randomSpawnPoint, Quaternion.identity);
        }
    }

    public void AddWaveIndex()
    {
        _currentWaveIndex++;
    }

    public void CheckReadyNextMap()
    {
        if(_currentWaveIndex == _waves.Count)
        {
            _currentMapIndex++;
            InnitMap(_currentMapIndex);
        }
    }

}

[Serializable]
public class MapConfigure
{
    [SerializeField] private GameObject _map;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<WaveConfigure> _waves;

    public GameObject Map { get => _map; set => _map = value; }
    public List<Transform> SpawnPoints { get => _spawnPoints; set => _spawnPoints = value; }
    public List<WaveConfigure> Waves { get => _waves; set => _waves = value; }
}
