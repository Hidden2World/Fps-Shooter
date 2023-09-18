using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audioSource; // Assign the Audio Source through the Unity Editor.

    void Start()
    {
        // Play the sound when the game starts.
        audioSource.Play();
    }
}
