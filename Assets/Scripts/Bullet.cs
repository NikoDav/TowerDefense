using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed { get => _speed; set => _speed = value; }

    public void Fire(Target target)
    {
        Debug.Log("Move");
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);
    }
}
