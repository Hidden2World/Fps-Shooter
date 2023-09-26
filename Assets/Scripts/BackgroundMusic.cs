using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        // Check if the AudioSource is valid and the audio clip is assigned.
        if (audioSource != null && audioSource.clip != null)
        {
            // Play the background music.
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Background music is not set up correctly!");
        }
    }

    public void OnGameOver()
    {

        audioSource.Stop();
    }
}
