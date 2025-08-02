using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyAttack _enemyAttack;
    private int _hp;
    public void Initialize(int hp)
    {
        _hp = hp;
    }

    public void TakeDamage(int amnt)
    {
        Debug.Log("enemy takes damage");
        _hp -= amnt;
        if(_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetNewTarget(Transform unit)
    {
        _enemyAttack.SetNewTarget(unit);
    }
}
