using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    [SerializeField] private List<SpawnTowerUI> _buttons = new List<SpawnTowerUI>();
    [SerializeField] private GameObject _scrollView;

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

    public void ActiveScrollView(bool isActive)
    {
        _scrollView.gameObject.SetActive(isActive);
    }
}
