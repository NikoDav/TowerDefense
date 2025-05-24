using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private EnemyConfig _enemyConfig;
    protected Transform _target;
    protected int _delay;
    protected int _damage;
    protected float _elapsedTime;
    private float _range;
    private float _hitRange;
    protected Animator _animator;


    private void Update()
    {
        
        if(_target == null)
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
