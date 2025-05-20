using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherUnitAttack : UnitAttack
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private Transform _shootPoint;
    private GameObject _currentArrow;
    public override void Attack()
    {
        float originalSpeed = _agent.speed;
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _delay)
        {
            _currentArrow = Instantiate(_arrow, _shootPoint.position, Quaternion.identity);
            _currentArrow.transform.LookAt(_target.transform);
            _target.SetNewTarget(this.transform);
            _elapsedTime = 0;
        }

        if (Vector3.Distance(transform.position, _target.transform.position) <= _hitRange)
        {
            _agent.speed = 0;
        }
        else
        {
            _agent.speed = originalSpeed;
        }
    }
}
