using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LF_AudioManager : MonoBehaviour
{
   [SerializeField]
   private AudioSource sfxSource = default;
   [SerializeField]
   private AudioSource ambienceSource = default;
   [SerializeField]
   private AudioClip music = default;
   private static LF_AudioManager _instance;


    // Start is called before the first frame update
    void Awake()
    {
       _instance = this;
       if (music) {
           ambienceSource.loop = true;
           ambienceSource.clip = music;
           ambienceSource.Play();
       }
    }

    public static void PlaySFX(AudioClip audioClip)
   {
       _instance.sfxSource.PlayOneShot(audioClip);
   }
   public static void SetAmbience(AudioClip audioClip)
   {
       _instance.ambienceSource.Stop();
       _instance.ambienceSource.clip = audioClip;
       _instance.ambienceSource.Play();
   }
    // Update is called once per frame
    void Update()
    {
        
    }
}
