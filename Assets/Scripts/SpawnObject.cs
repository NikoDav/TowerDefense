using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private Material _red;
    [SerializeField] private Material _green;
    [SerializeField] private MeshRenderer _currentObject;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _collisionLayer;
    [SerializeField] private SpawnObjectType _spawnObjectType;
    [SerializeField] private AudioSource _audioSource;
    private Material _default;
    private bool _canSpawn = false;
    private bool _isSpawned = false;

    public SpawnObjectType SpawnObjectType { get => _spawnObjectType; set => _spawnObjectType = value; }

    public event UnityAction _spawned;

    private void Start()
    {
        _default = _currentObject.material;
    }
    private void Update()
    {
        if (!_isSpawned)
        {
            Debug.Log(Physics.OverlapSphere(transform.position, _radius).Length);
            if (Physics.CheckSphere(transform.position, _radius, _collisionLayer))
            {
                _canSpawn = false;
                _currentObject.material = _red;
            }
            else if(Physics.OverlapSphere(transform.position, _radius).Length == 0){
                _canSpawn = false;
                _currentObject.material = _red;
            }
            else
            {
                _canSpawn = true;
                _currentObject.material = _green;
            }
        }
        
    }

    public bool Place()
    {
        if(_canSpawn)
        {
            _currentObject.material = _default;
            _isSpawned = true;
            _audioSource.Play();
            _spawned?.Invoke();
            return true;
        }
        return false;
    }
}
