using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private Material _red;
    [SerializeField] private Material _green;
    [SerializeField] private MeshRenderer _currentObject;
    private Material _default;

    private void Start()
    {
        _default = _currentObject.material;
    }

    public void ChangeMaterial(bool canPlace)
    {
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
