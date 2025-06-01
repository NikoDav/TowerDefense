using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarracksTower : Tower
{
    [SerializeField] private Transform _spawnPoint;
    private float _elapsedTime;

    public void OnEnable()
    {
        base.OnEnable();
        Clicked += OnClicked;
        Deactivate += OnDeactivate;
    }

    public void OnDisable()
    {
        base.OnDisable();
        Clicked -= OnClicked;
        Deactivate -= OnDeactivate;
    }
    public void OnClicked()
    {
        FindObjectOfType<UnitSelector>().Click(_index);
        FindObjectOfType<UnitSelector>().ActiveScrollView(true);
    }

    public void OnDeactivate()
    {
        FindObjectOfType<UnitSelector>().ActiveScrollView(false);
    }


    private void Spawn()
    {
       
    }
}
