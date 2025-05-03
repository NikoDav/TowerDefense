using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "tower", menuName = "CreateTower")]
public class TowerConfig : ScriptableObject
{
    [SerializeField] private List<TowerLevel> _towerLevels = new List<TowerLevel>();

    public List<TowerLevel> TowerLevels { get => _towerLevels; set => _towerLevels = value; }
}
