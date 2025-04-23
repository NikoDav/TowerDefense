using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private SpawnObjectType _towerType;
    private TowerSelector _towerSelector;

    private void Start()
    {
        _towerSelector = FindObjectOfType<TowerSelector>();
    }

    public void Select()
    {
        _towerSelector.SelectTower(_towerType);
    }
}
