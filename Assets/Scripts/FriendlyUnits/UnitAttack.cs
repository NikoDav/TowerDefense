using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitAttack : MonoBehaviour
{
    [SerializeField] protected LayerMask _enemyLayer;

    protected int _damage;
    protected float _range;
    protected NavMeshAgent _agent;
    protected EnemyHealth _target;
    protected int _delay;
    protected float _elapsedTime;
    protected float _hitRange;
    protected Animator _animator;
    

    public void Initialized(int damage, float range, NavMeshAgent agent, int delay, float hitRange, Animator animator)
    {
        _damage = damage;
        _range = range;
        _agent = agent;
        _delay = delay;
        _hitRange = hitRange;
        _animator = animator;
    }

    private void Update()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _range, _enemyLayer);
        Debug.Log(enemies.Length);
        if (enemies.Length > 0 && _target == null)
        {
            Debug.Log("SetTarget");
            _target = enemies[0].gameObject.GetComponent<EnemyHealth>();
        }

        if (_target != null)
        {
            Debug.Log("SetDestination");
            _agent.SetDestination(_target.transform.position);
            if (Vector3.Distance(transform.position, _target.transform.position) <= _hitRange)
            {
                Debug.Log("Attack");
                Attack();
            }

            transform.LookAt(_target.transform);

        }
    }

    public abstract void Attack();
}
