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
        ShootingTower tower = _towerConfig.TowerLevels[_index] as ShootingTower;

        Collider[] enemies = Physics.OverlapSphere(transform.position, tower.Range, _enemyLayer);
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
        ShootingTower tower = _towerConfig.TowerLevels[_index] as ShootingTower;
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= tower.FireRate && Vector3.Distance(transform.position, _target.transform.position) < tower.Range)
        {
            _currentBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            _currentBullet.transform.LookAt(_target.transform);
            _elapsedTime = 0;
        }
    }

    private void OnDrawGizmos()
    {
        ShootingTower tower = _towerConfig.TowerLevels[_index] as ShootingTower;
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, tower.Range);
    }


}
