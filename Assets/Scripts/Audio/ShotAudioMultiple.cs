using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAudioMultiple : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();
    private void Start()
    {
        _audioSource.pitch = Random.Range(0.5f, 1.5f);
        _audioSource.clip = _audioClips[Random.Range(0, _audioClips.Count)];
        Destroy(gameObject, _audioSource.clip.length);
    }
}
