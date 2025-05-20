using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSoldier : Enemy
{
    private void Attack()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _delay)
        {
            IDamagable opponent = _target.GetComponent<IDamagable>();
            opponent.TakeDamage(_damage);
            _elapsedTime = 0;
        }
    }

}
