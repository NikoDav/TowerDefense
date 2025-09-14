using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDemon : EnemyAttack
{
    [SerializeField] private Bullet _fireball;
    [SerializeField] private Transform _shootPoint;
    private Bullet _currentBullet;
    public override void Attack()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _delay)
        {
            _elapsedTime = 0;
            _currentBullet = Instantiate(_fireball, _shootPoint.position, Quaternion.identity);
            _currentBullet.transform.LookAt(_target.transform);
        }

    }

    public override void SetNewTarget(Transform unit)
    {
        throw new System.NotImplementedException();
    }
}
