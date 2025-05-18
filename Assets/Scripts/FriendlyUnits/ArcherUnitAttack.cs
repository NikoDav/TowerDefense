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
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _delay)
        {
            _currentArrow = Instantiate(_arrow, _shootPoint.position, Quaternion.identity);
            _currentArrow.transform.LookAt(_target.transform);
            _target.SetNewTarget(this.transform);
            _elapsedTime = 0;
        }
    }
}
