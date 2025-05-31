using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarracksTower : Tower
{
    [SerializeField] private Transform _spawnPoint;
    private float _elapsedTime;

    private void OnEnable()
    {
        Clicked += OnClicked;
    }

    private void OnDisable()
    {
        Clicked -= OnClicked;
    }
    public void OnClicked()
    {
        FindObjectOfType<UnitSelector>().Click(_index);
    }
    private void Spawn()
    {
       
    }
}
