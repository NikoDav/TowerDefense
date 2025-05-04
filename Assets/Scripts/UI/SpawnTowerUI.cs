using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTowerUI : MonoBehaviour
{
    [SerializeField] private GameObject _unit;

    public GameObject Unit { get => _unit; set => _unit = value; }
}
