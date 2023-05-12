using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaythrough : MonoBehaviour
{
    public AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying)
        {
            Debug.Log("NotPlayin");
            return;
        }
        else
        {
            Debug.Log("Playin");
            audioSource.Play();
        }
    }
}
