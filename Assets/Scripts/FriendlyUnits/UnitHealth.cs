using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IDamagable, IDestroyable
{
    private int _health;
    public void Initialized(int health)
    {
        _health = health;
    }

    public void TakeDamage(int dmg)
    {
        _health -= dmg;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
