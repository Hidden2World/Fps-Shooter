using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public AudioSource gunshotSound; // Reference to the AudioSource with the gunshot sound.

    void Update()
    {
        // Check for left mouse button click.
        if (Input.GetButtonDown("Fire1"))
        {
            FirePistol(); // Call the method to handle firing the pistol.
        }
    }

    void FirePistol()
    {
        // Play the gunshot sound.
        if (gunshotSound != null)
        {
            gunshotSound.Play();
        }

        // Implement the rest of your pistol firing logic here.
        // For example, you can instantiate bullets, apply forces, and deal damage to targets.
    }
}
