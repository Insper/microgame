using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fernando{
    public class EnemyController : MonoBehaviour{
        private AudioSource _audioSource;
        public AudioClip LoseClip;
        public float velocity;
        private Vector3 direction;
        private MicrogameInternal.GameManager gm;
        private float shootDelay = 1.0f;
        private float _lastShootTimestamp = 0.0f;

        void Start(){
            _audioSource = GetComponent<AudioSource>();
            gm = MicrogameInternal.GameManager.GetInstance();
            velocity = (1.0f+GenerateRandomNumber(gm.ActiveLevel))/2.0f;
            direction = new Vector3(1.0f, 0.0f);
        }

        void Update(){
            
            if (Time.time - _lastShootTimestamp >= shootDelay){
                _lastShootTimestamp = Time.time;
                 velocity *= 1.05f;
            }
            transform.position += direction*Time.deltaTime*velocity;
            CheckPosition();
        }

        void CheckPosition(){
            float currentPosition = transform.position.x;
            if (currentPosition >= 6) {
                _audioSource.clip = LoseClip;
                _audioSource.Play();
                gm.GameLost(); 
            }
        }

        float GenerateRandomNumber(int x){
            return (float)Random.Range(x, x+2);
        }
    }
}

