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
            Debug.Log("SetTarget");
            _target = enemies[0].gameObject.GetComponent<Enemy>();
        }

        if(_target != null)
        {
            Debug.Log("SetDestination");
            _agent.SetDestination(_target.transform.position);
            if(Vector3.Distance(transform.position, _target.transform.position) <= 1)
            {
                Debug.Log("Attack");
                Attack();
            }
        }
    }

    private void Attack()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime>= _delay)
        {
            _target.TakeDamage(_damage);
            _elapsedTime = 0;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _range);
    }
}
