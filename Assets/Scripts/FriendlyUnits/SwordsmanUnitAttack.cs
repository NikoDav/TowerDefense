using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanUnitAttack : UnitAttack
{
    private void Update()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _range, _enemyLayer);
        if (enemies.Length > 0 && _target == null)
        {
            _target = enemies[0].gameObject.GetComponent<Enemy>();
        }

        if(_target != null)
        {
            _agent.SetDestination(_target.transform.position);
        }
    }

    private void Attack()
    {
        if(_elapsedTime>= _delay)
        {
            _target.TakeDamage(_damage);
            _elapsedTime = 0;
        }
    }
}
