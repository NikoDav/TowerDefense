using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using System.Linq;

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
        StartCoroutine(SpawnEnemiesDelay());
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
        var destroyableObjects = FindObjectsByInterface<IDestroyable>();
        foreach(var objectDestroy in destroyableObjects)
        {
            objectDestroy.Destroy();
        }
    }

    public static T[] FindObjectsByInterface<T>() where T : class
    {
        return GameObject.FindObjectsOfType<MonoBehaviour>()
                        .OfType<T>()
                        .ToArray();
    }
    private IEnumerator SpawnEnemiesDelay()
        {
            List<EnemySpawnList> enemies = _waves[_currentWaveIndex].Enemies;

            for (int i = 0; i < enemies.Count; i++)
            {
                EnemySpawnList newEnemySpawnList = enemies[i];
                for(int j = 0; j < newEnemySpawnList.Amount; j++)
                {
                    Vector3 randomSpawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].transform.position;

                    Instantiate(newEnemySpawnList.Enemy, randomSpawnPoint, Quaternion.identity);
                    yield return new WaitForSeconds(0.3f);
                }
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
