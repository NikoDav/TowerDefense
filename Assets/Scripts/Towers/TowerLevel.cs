using UnityEngine;
using System;


public abstract class TowerLevel : ScriptableObject
{
    [SerializeField] private int _cost;
    [SerializeField] private int _levelIndex;
    [SerializeField] private Mesh _buildingMesh;
    [SerializeField] private Mesh _finalMesh;

    public int Cost { get => _cost; set => _cost = value; }
    public int LevelIndex { get => _levelIndex; set => _levelIndex = value; }
    public Mesh BuildingMesh { get => _buildingMesh; set => _buildingMesh = value; }
    public Mesh FinalMesh { get => _finalMesh; set => _finalMesh = value; }
}
