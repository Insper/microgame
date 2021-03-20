using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [SerializeField]
   private AudioSource sfxSource = default;
   [SerializeField]
   private AudioSource ambienceSource = default;
   [SerializeField]
   private AudioClip music = default;
   private static AudioManager _instance;
}