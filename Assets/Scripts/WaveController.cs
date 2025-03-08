using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveController : MonoBehaviour
{
    [SerializeField] private List<Map> _map;
}

[Serializable]
public class Map
{
    [SerializeField] private GameObject _map;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<WaveConfigure> _waves;
}
