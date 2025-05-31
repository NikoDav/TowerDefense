using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    [SerializeField] private List<SpawnTowerUI> _buttons = new List<SpawnTowerUI>();

    public void Click(int level)
    {
        for(int i = 0; i < level; i++)
        {
            _buttons[i].gameObject.SetActive(true);
        }
    }
}
