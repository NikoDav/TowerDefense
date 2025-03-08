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

    private void Start()
    {
        InnitMap(_currentMapIndex);
    }

    private void InnitMap(int index)
    {
        _map = _maps[index].Map;
        _spawnPoints = _maps[index].SpawnPoints;
        _waves = _maps[index].Waves;

        _map.SetActive(true);
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
