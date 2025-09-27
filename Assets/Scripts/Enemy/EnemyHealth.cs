using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDestroyable
{
    [SerializeField] private EnemyAttack _enemyAttack;
    private int _hp;
    public void Initialize(int hp)
    {
        _hp = hp;
    }

    public void TakeDamage(int amnt)
    {
        _hp -= amnt;
        if(_hp <= 0)
        {
            Destroy();
        }
    }

    public void SetNewTarget(Transform unit)
    {
        _enemyAttack.SetNewTarget(unit);
    }
    public void Destroy()
    {
        if (transform.parent == null)
            Destroy(gameObject);
        else
            Destroy(gameObject.transform.parent.gameObject);
    }
}
