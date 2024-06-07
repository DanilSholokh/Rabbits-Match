using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else { audioSource.Stop(); }

    }
}
