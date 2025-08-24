using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDestroyable
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private ShotAudio _shotAudio;

    public float Speed { get => _speed; set => _speed = value; }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnemyHealth enemy))
        {
            Debug.Log("shot fired");
            enemy.TakeDamage(_damage);
            Instantiate(_shotAudio);
            Destroy(gameObject);
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
