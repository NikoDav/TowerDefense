using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private EnemyConfig _enemyConfig;
    private int _hp;
    private Transform _target;
    private int _delay;
    private int _damage;
    private float _elapsedTime;


    private void Update()
    {
        _navMeshAgent.SetDestination(_target.position);
        if(_target == null)
        {
            _target = FindObjectOfType<Castle>().transform;
        }
        else
        {
            if (Vector3.Distance(transform.position, _target.transform.position) <= 1)
            {
                Debug.Log("Attack");
                Attack();
            }
        }
    }

    private void Start()
    {
        _target = FindObjectOfType<Castle>().transform;
        _hp = _enemyConfig.Hp;
        _delay = _enemyConfig.Delay;
        _damage = _enemyConfig.Damage;
    }

    public void TakeDamage(int amnt)
    {
        _hp -= amnt;
        if(_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetNewTarget(Transform unit)
    {
        _target = unit;
    }

    private void Attack()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _delay)
        {
            IDamagable opponent = _target.GetComponent<IDamagable>();
            opponent.TakeDamage(_damage);
            _elapsedTime = 0;
        }
    }
}
