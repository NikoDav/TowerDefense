using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAttack : MonoBehaviour
{
    private EnemyConfig _enemyConfig;
    private float _range;

    protected NavMeshAgent _navMeshAgent;
    protected Transform _target;
    protected int _delay;
    protected int _damage;
    protected float _elapsedTime;
    protected float _hitRange;
    protected Animator _animator;


    private void Update()
    {
        float originalSpeed = _navMeshAgent.speed;
        if (_target == null)
        {
            _target = FindObjectOfType<Castle>().transform;
        }
        else
        {
            if (Vector3.Distance(transform.position, _target.transform.position) <= _hitRange)
            {
                Debug.Log("Attack");
                Attack();
            }
        }
        _navMeshAgent.SetDestination(_target.position);
        if (Vector3.Distance(transform.position, _target.transform.position) <= _hitRange)
        {
            _navMeshAgent.speed = 0;
        }
        else
        {
            _navMeshAgent.speed = originalSpeed;
        }
    }

    private void Start()
    {
        _target = FindObjectOfType<Castle>().transform;
    }

    public void Initialized(int damage, float range, NavMeshAgent agent, int delay, float hitRange, Animator animator)
    {
        _damage = damage;
        _range = range;
        _navMeshAgent = agent;
        _delay = delay;
        _hitRange = hitRange;
        _animator = animator;
    }

    

    public void SetNewTarget(Transform unit)
    {
        _target = unit;
    }

    public abstract void Attack();

 
}
