using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _borderThickness;
    [SerializeField] private Vector3 minPos;
    [SerializeField] private Vector3 maxPos;

    private void Update()
    {
        if(Input.mousePosition.y >= Screen.height - _borderThickness)
        {
            transform.position += Vector3.back * _speed * Time.deltaTime;
        }

        if(Input.mousePosition.y < _borderThickness)
        {
            transform.position += Vector3.forward * _speed * Time.deltaTime;
        }

        if(Input.mousePosition.x >= Screen.width - _borderThickness)
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
        if (Input.mousePosition.x < _borderThickness)
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }

        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minPos.x, maxPos.x);
        clampedPos.y = Mathf.Clamp(clampedPos.y, minPos.y, maxPos.y);
        clampedPos.z = Mathf.Clamp(clampedPos.z, minPos.z, maxPos.z);
        transform.position = clampedPos;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 newPos = transform.position + transform.forward * scroll * _zoomSpeed;
        transform.position = newPos;
    }
}
