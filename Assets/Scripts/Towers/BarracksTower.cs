using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarracksTower : Tower
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private List<Button> _buttons = new List<Button>();
    private float _elapsedTime;

}
