using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaying : MonoBehaviour
{
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Stop();
    }

    void Start()
    {
        GameManager.Instance.MusicStarting += Play;
        GameManager.Instance.QuietMusic += QuietVolumeMusic;
        GameManager.Instance.RestartVolume += RestartingVolume;
    }

    private void Play()
    {
        _audioSource.Play();
    }

    private void QuietVolumeMusic()
    {
        _audioSource.volume = Mathf.Lerp(1.0f, 0.2f, 10);
    }

    private void RestartingVolume()
    {
        _audioSource.volume = Mathf.Lerp(0.2f, 1.0f, 10);
    }

    private void OnDestroy()
    {
        GameManager.Instance.MusicStarting -= Play;
        GameManager.Instance.QuietMusic -= QuietVolumeMusic;
        GameManager.Instance.RestartVolume -= RestartingVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
