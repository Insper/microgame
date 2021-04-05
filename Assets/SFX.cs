using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip handBreakSFX;
    public AudioClip woodBreakSFX;

    public void PlayWoodSFX()
        {
            audioSource.PlayOneShot(woodBreakSFX);
        }
    public void PlayHandSFX()
    {
        audioSource.PlayOneShot(handBreakSFX);
    }
}
