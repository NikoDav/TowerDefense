using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarracksTower : Tower
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private List<SpawnTowerUI> _buttons = new List<SpawnTowerUI>();
    private float _elapsedTime;


    private void Spawn()
    {
       
    }

}
