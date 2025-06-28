using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private void Start()
    {
        _audioSource.pitch = Random.Range(0.5f, 1.5f);
        Destroy(gameObject, _audioSource.clip.length);
    }
}
