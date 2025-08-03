using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class WaveController : MonoBehaviour
{
    [SerializeField] private List<MapConfigure> _maps;
    [SerializeField] private NavMeshSurface _navMeshSurface;
    [SerializeField] private Transform _camera;
    [SerializeField] private GameObject _winPanel;
    private Vector3 _cameraStartPos;
    private GameObject _map;
    private List<Transform> _spawnPoints;
    private List<WaveConfigure> _waves;
    private int _currentMapIndex = 0;
    private int _currentWaveIndex = 0;

    private void Start()
    {
        _cameraStartPos = _camera.position;
        InnitMap(_currentMapIndex);
    }

    private void InnitMap(int index)
    {
        if(_map != null)
        {
            _map.SetActive(false);
            ScreenClear();
        }
        _map = _maps[index].Map;
        _spawnPoints = _maps[index].SpawnPoints;
        _waves = _maps[index].Waves;
        _camera.position = _cameraStartPos;

        _currentWaveIndex = 0;

        _map.SetActive(true);
        _navMeshSurface.BuildNavMesh();
    }

    public void SpawnEnemies()
    {
        int enemiesAmount = _waves[_currentWaveIndex].EnemiesAmount;
        List<EnemyAttack> enemies = _waves[_currentWaveIndex].Enemies;

        for (int i = 0; i < enemiesAmount; i++)
        {
            EnemyAttack newEnemy = enemies[UnityEngine.Random.Range(0, _waves[_currentWaveIndex].Enemies.Count)];
            Vector3 randomSpawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].transform.position;

            Instantiate(newEnemy, randomSpawnPoint, Quaternion.identity);
        }
    }

    public void AddWaveIndex()
    {
        WavePrize();
        _currentWaveIndex++;
    }

    private void WavePrize()
    {
        Money.Instance.addMoney(_waves[_currentWaveIndex].Reward);
    }

    public void CheckReadyNextMap()
    {
        if(_currentWaveIndex == _waves.Count)
        {
            ShowWinPanel();
        }
    }

    private void ShowWinPanel()
    {
        Time.timeScale = 0;
        _winPanel.SetActive(true);
    }

    public void SetNextMap()
    {
        Time.timeScale = 1;
        _winPanel.SetActive(false);
        _currentMapIndex++;
        InnitMap(_currentMapIndex);
    }

    private void ScreenClear()
    {
        var enemies = FindObjectsOfType<EnemyHealth>();
        foreach(var enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        var units = FindObjectsOfType<UnitHealth>();
        foreach (var unit in units)
        {
            Destroy(unit.gameObject);
        }
        var towers = FindObjectsOfType<SpawnObject>();
        foreach (var tower in towers)
        {
            Destroy(tower.gameObject);
        }
        var arrows = FindObjectsOfType<Bullet>();
        foreach (var arrow in arrows)
        {
            Destroy(arrow.gameObject);
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
