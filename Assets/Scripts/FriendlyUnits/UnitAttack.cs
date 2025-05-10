using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAttack : MonoBehaviour
{
    protected int _damage;
    protected float _range;
    protected NavMeshAgent _agent;
    protected GameObject _target;
    protected int _delay;
    [SerializeField] protected LayerMask _enemyLayer;

    public void Initialized(int damage, float range, NavMeshAgent agent, int delay)
    {
        _damage = damage;
        _range = range;
        _agent = agent;
        _delay = delay;
    }
}
