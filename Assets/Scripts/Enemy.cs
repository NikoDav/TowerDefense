using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _target;
    [SerializeField] private int _hp;


    private void Update()
    {
        _navMeshAgent.SetDestination(_target.position);
    }

    private void Start()
    {
        _target = FindObjectOfType<Castle>().transform;
    }

    public void TakeDamage(int amnt)
    {
        _hp -= amnt;
        if(_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
