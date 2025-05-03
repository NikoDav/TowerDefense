using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LayerMask _enemyLayer;
    private bool _canShoot;
    private GameObject _target;
    private float _elapsedTime;
    private Bullet _currentBullet;

    private void FixedUpdate()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _towerConfig.TowerLevels[_index].Range, _enemyLayer);
        if (enemies.Length > 0)
        {
            _target = enemies[0].gameObject;
        }
    }

    private void Update()
    {
        base.Update();
        if (_target != null)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _towerConfig.TowerLevels[_index].FireRate && Vector3.Distance(transform.position, _target.transform.position) < _towerConfig.TowerLevels[_index].Range)
        {
            _currentBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            _currentBullet.transform.LookAt(_target.transform);
            _elapsedTime = 0;
        }
    }


}
