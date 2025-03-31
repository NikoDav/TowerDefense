using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "tower", menuName = "CreateTower")]
public class TowerConfig : ScriptableObject
{
    [SerializeField] private List<TowerLevel> _towerLevels = new List<TowerLevel>();

    public List<TowerLevel> TowerLevels { get => _towerLevels; set => _towerLevels = value; }
}

[Serializable]
public class TowerLevel
{
    [SerializeField] private int _cost;
    [SerializeField] private int _dmg;
    [SerializeField] private float _range;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _levelIndex;
    [SerializeField] private Mesh _buildingMesh;
    [SerializeField] private Mesh _finalMesh;

    public int Cost { get => _cost; set => _cost = value; }
    public int Dmg { get => _dmg; set => _dmg = value; }
    public float Range { get => _range; set => _range = value; }
    public float FireRate { get => _fireRate; set => _fireRate = value; }
    public int LevelIndex { get => _levelIndex; set => _levelIndex = value; }
    public Mesh BuildingMesh { get => _buildingMesh; set => _buildingMesh = value; }
    public Mesh FinalMesh { get => _finalMesh; set => _finalMesh = value; }
}
