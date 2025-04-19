using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private GameObject _tower;
    [SerializeField] private float _maxDistance;
    [SerializeField] private SpawnObject _spawnObject;

    private void Update()
    {
        if(_tower != null)
        {
            FollowMouse();
        }
    }

    private void FollowMouse()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundLayer))
        {
            _tower.transform.position = hit.point;
            _spawnObject.ChangeMaterial(true);
        }
        else
        {
            if (Physics.Raycast(ray, out RaycastHit hit2, Mathf.Infinity, ~_groundLayer) && hit2.collider.gameObject != _tower)
            {
                _tower.transform.position = hit2.point;
                _spawnObject.ChangeMaterial(false);
            }
            else
            {
                _spawnObject.ChangeMaterial(false);
                _tower.transform.position = ray.GetPoint(_maxDistance);
            }
        }
    }
}
