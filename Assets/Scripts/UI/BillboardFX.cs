using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardFX : MonoBehaviour
{
    private Transform _camera;
    private Quaternion _originalRotation;


    private void Start()
    {
        _camera = Camera.main.transform;
        _originalRotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = _camera.rotation * _originalRotation;
    }
}
