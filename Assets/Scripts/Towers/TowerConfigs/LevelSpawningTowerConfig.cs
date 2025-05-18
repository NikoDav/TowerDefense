using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawningTower", menuName = "Tower/CreateSpawningTowerLevel")]
public class LevelSpawningTowerConfig : TowerLevelBaseConfig
{
    [SerializeField] private float _spawnDelay = 2;

    public float SpawnDelay => _spawnDelay;
}
