using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    [SerializeField] private List<SpawnTowerUI> _buttons = new List<SpawnTowerUI>();
    [SerializeField] private GameObject _scrollView;
    [SerializeField] private Money _money;

    private Transform _spawnPoint;

    private void OnEnable()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].Clicked += Spawn;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].Clicked -= Spawn;
        }
    }

    private void Spawn(GameObject arg0)
    {
        Instantiate(arg0, _spawnPoint.position, _spawnPoint.rotation);
    }

    public void Click(int level)
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].SetInetractable(false);
        }
            for (int i = 0; i < level; i++)
        {
            _buttons[i].SetInetractable(true);
        }
    }

    public void ActiveScrollView(bool isActive, Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
        _scrollView.gameObject.SetActive(isActive);
    }
}
