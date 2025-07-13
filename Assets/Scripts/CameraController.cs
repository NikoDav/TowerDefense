using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _borderThickness;
    [SerializeField] private Vector2 misPos;
    [SerializeField] private Vector2 maxPos;

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
    }
}
