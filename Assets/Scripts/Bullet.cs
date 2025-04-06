using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed { get => _speed; set => _speed = value; }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }


}
