using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerConfig _towerConfig;
    [SerializeField] private MeshFilter _meshFilter;
    private int _index;

    [ContextMenu("LevelUp")]
    public void LevelUp()
    {
        _index++;
        _meshFilter.mesh = _towerConfig.TowerLevels[_index - 1].BuildingMesh;
    }
}
