using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druid : EnemyAttack
{
    public override void Attack()
    {

        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _delay)
        {
            IDamagable opponent = _target.GetComponent<IDamagable>();
            opponent.TakeDamage(_damage);
            _animator.SetTrigger("Hit");
            _elapsedTime = 0;
        }


    }
}
