using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAttack : MonoBehaviour
{
    private int _damage;
    private float _range;
    private NavMeshAgent _agent;

    public void Initialized(int damage, float range, NavMeshAgent agent)
    {
        _damage = damage;
        _range = range;
        _agent = agent;
    }
}
