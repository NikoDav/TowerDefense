using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _target;


    private void Update()
    {
        _navMeshAgent.SetDestination(_target.position);
    }

    private void Start()
    {
        _target = FindObjectOfType<Castle>().transform;
    }
}
