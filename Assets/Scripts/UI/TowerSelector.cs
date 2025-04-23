using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    [SerializeField] private List<SpawnObject> _spawnObjects;
    private TowerSpawner _towerSpawner;

    private void Start()
    {
        _towerSpawner = FindObjectOfType<TowerSpawner>();
    }
    public void SelectTower(SpawnObjectType spawnObjectType)
    {
        foreach(SpawnObject obj in _spawnObjects)
        {
            if (obj.SpawnObjectType == spawnObjectType)
            {
                _towerSpawner.SetSpawnObject(Instantiate(obj));
            }
        }
    }
}

public enum SpawnObjectType
{
    None,
    Archer,
    Magic,
    Barracks,
    Canon
}
