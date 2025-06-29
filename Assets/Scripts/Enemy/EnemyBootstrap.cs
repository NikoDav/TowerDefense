using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBootstrap : MonoBehaviour
{
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private EnemyHealth _enemyHp;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _enemyAttack.Initialized(_enemyConfig.Damage, _enemyConfig.Range, _navMesh, _enemyConfig.Delay, _enemyConfig.HitRange, _animator);
        _navMesh.stoppingDistance = _enemyConfig.HitRange;
        _enemyHp.Initialize(_enemyConfig.Hp);
    }
}
