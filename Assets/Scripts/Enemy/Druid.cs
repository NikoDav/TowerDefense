using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druid : EnemyAttack
{
    [SerializeField] private DruidVine _druidVine;
    public override void Attack()
    {

        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _delay)
        {
            _animator.SetTrigger("Hit");
            _elapsedTime = 0;
        }


    }

    public override void SetNewTarget(Transform unit)
    {
        _elapsedTime = float.MaxValue;
        _target = unit;
    }

    public void AttackWithVines()
    {
        List<IDamagable> damagables = _druidVine.CheckTrigger();
        foreach(IDamagable damagable in damagables)
        {
            damagable.TakeDamage(_damage);
        }
    }
}
