using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _maxDistance;
    [SerializeField] private SpawnObject _spawnObject;


    private void Update()
    {
        if(_spawnObject != null)
        {
            FollowMouse();
            if (Input.GetMouseButton(0))
            {
                if (_spawnObject.Place())
                    _spawnObject = null;
            }
        }

        
    }

    private void FollowMouse()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundLayer))
        {
            _spawnObject.transform.position = hit.point;
        }
        else
        {
            if (Physics.Raycast(ray, out RaycastHit hit2, Mathf.Infinity, ~_groundLayer) && hit2.collider.gameObject != _spawnObject.gameObject)
            {
                _spawnObject.transform.position = hit2.point;
            }
            else
            {
                _spawnObject.transform.position = ray.GetPoint(_maxDistance);
            }
        }
    }
}
