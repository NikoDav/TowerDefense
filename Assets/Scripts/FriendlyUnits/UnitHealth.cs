using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    private int _health;
    public void Initialized(int health)
    {
        _health = health;
    }
}
