using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource enemyAudioSource;
    
    private void Awake()
    {
        enemyAudioSource = GetComponent<AudioSource>();
        
        int numMusicPlayer = FindObjectsOfType<MusicManager>().Length;
        if (numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void MusicOn(AudioClip audioClip)
    {
        enemyAudioSource.PlayOneShot(audioClip);
    }
}
