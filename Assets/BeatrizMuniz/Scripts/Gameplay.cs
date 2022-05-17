using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bilbia {
    public class Gameplay : MonoBehaviour
    {
        public int currentKeyIndex;
        public int currentKey;
        public AudioClip[] notesAudio;
        public AudioClip[] chordsAudio;
        public AudioSource audioSource;
        public AudioClip wrongNote;

        public GameObject notes;
        public List<int> keys;
        public List<GameObject> keyObjects;

        public GameObject strings;

        private MicrogameInternal.GameManager gm;
        [SerializeField]private GameObject _instructions;

        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            currentKeyIndex = 0;
            keys = notes.GetComponent<NotesSpawner>().keys;
            keyObjects = notes.GetComponent<NotesSpawner>().keyObjects;
            currentKey = keys[currentKeyIndex];
            Invoke(nameof(Begin), 0.5f); 
        }

        void Update()
        {
            if(currentKeyIndex < 5){
                currentKey = keys[currentKeyIndex];
                if(Input.anyKeyDown){
                    if (currentKey == 0 && Input.GetKeyDown(KeyCode.UpArrow)){
                        PressedButton();
                        PlaySound();
                        currentKeyIndex ++;
                    }
                    else if (currentKey == 1 && Input.GetKeyDown(KeyCode.DownArrow)){
                        PressedButton();
                        PlaySound();
                        currentKeyIndex ++;
                    }
                    else if (currentKey == 2 && Input.GetKeyDown(KeyCode.LeftArrow)){
                        PressedButton();
                        PlaySound();
                        currentKeyIndex ++;
                    }
                    else if (currentKey == 3 && Input.GetKeyDown(KeyCode.RightArrow)){
                        PressedButton();
                        PlaySound();
                        currentKeyIndex ++;
                    }
                    else if (currentKey == 4 && Input.GetKeyDown(KeyCode.Space)){
                        PressedButton();
                        PlayChord();
                        currentKeyIndex ++;
                    }

                    else{
                        audioSource.clip = wrongNote;
                        audioSource.pitch = 0.2f;
                        audioSource.Play();
                        strings.GetComponent<StringsManager>().DamageString();
                    }
                }
            } 
        }   

        void Begin() 
        {
            _instructions.SetActive(false);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
        }

        void EndCheck() 
        {
            if(currentKeyIndex < 5) {
                gm.GameLost(); 
            } 
        }

        public void PlaySound()
        {
            audioSource.clip = notesAudio[Random.Range(0, notesAudio.Length)];
            audioSource.pitch = 1f;
            audioSource.Play();
        }

        public void PlayChord()
        {
            audioSource.clip = chordsAudio[Random.Range(0, chordsAudio.Length)];
            audioSource.pitch = 1f;
            audioSource.Play();
        }

        public void PressedButton()
        {
            GameObject key = keyObjects[currentKeyIndex];
            SpriteRenderer sprite = key.GetComponent<SpriteRenderer>();
            sprite.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
    }
}