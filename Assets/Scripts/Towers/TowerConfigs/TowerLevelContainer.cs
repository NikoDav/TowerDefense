using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "tower", menuName = "CreateTower")]
public class TowerLevelContainer : ScriptableObject
{
    [SerializeField] private List<TowerLevelBaseConfig> _towerLevels = new List<TowerLevelBaseConfig>();

    public List<TowerLevelBaseConfig> TowerLevels { get => _towerLevels; set => _towerLevels = value; }
}
