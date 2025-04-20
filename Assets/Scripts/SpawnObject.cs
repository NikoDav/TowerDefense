using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private Material _red;
    [SerializeField] private Material _green;
    [SerializeField] private MeshRenderer _currentObject;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _collisionLayer;
    private Material _default;
    private bool _canSpawn = false;

    private void Start()
    {
        _default = _currentObject.material;
    }
    private void Update()
    {
        if(Physics.CheckSphere(transform.position, _radius, _collisionLayer))
        {
            _canSpawn = false;
            _currentObject.material = _red;
        }
        else
        {
            _canSpawn = true;
            _currentObject.material = _green;
        }
    }
    public void ChangeMaterial(bool canPlace)
    {
        if (!_canSpawn)
            return;
        if (canPlace)
        {
            _currentObject.material = _green;
        }
        else
        {
            _currentObject.material = _red;
        }
    }

    public void SetDefault()
    {
        _currentObject.material = default;
    }
}
