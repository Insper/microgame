using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    private AudioSource _audioSource;
    public AudioClip WinClip;
    private float velocity = 0.0f;
    private Vector3 direction;
    private int desiredButtonIndex;
    List<string> buttonsSequencies = new List<string>();
    private MicrogameInternal.GameManager gm;
    private float force = 0.1f;

    void Start(){
        _audioSource = GetComponent<AudioSource>();
        gm = MicrogameInternal.GameManager.GetInstance();
        gm.StartTimer();
        buttonsSequencies.Add("left");
        buttonsSequencies.Add("right");
        direction = new Vector3(1.0f, 0.0f);
        desiredButtonIndex = 0;
    }

    void Update(){
        CheckMoviment();
        CheckPosition();
    }

    void CheckPosition(){
        float currentPosition = transform.position.x;
        if (currentPosition >= 6) {
            _audioSource.clip = WinClip;
            _audioSource.Play();
            gm.NextGame();
        } 
    }

    void CheckMoviment(){
        if (buttonsSequencies[desiredButtonIndex] == "left" && Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.position += direction*Time.deltaTime*velocity;
            SetNextMoviment();
         }
        else if (buttonsSequencies[desiredButtonIndex] == "right" && Input.GetKeyDown(KeyCode.RightArrow)){
            transform.position += direction*Time.deltaTime*velocity;
            SetNextMoviment();
        } 
        else{
            setForce(-0.005f);
            transform.position += direction*Time.deltaTime*force;
        }
    }

    void SetNextMoviment(){
        increaseVelocity();
        setForce(1.0f);
        desiredButtonIndex++;
        if (desiredButtonIndex > buttonsSequencies.Count-1) desiredButtonIndex = 0; 
    }

    void increaseVelocity(){
        if (velocity < 5){
            velocity += 0.3f;
        }
    }

    void setForce(float sum){
        force += sum;
        print(velocity);
        if (force >= velocity){
            force = velocity;
        }
        if (force < 0){
            force = 0.5f;
        }
    }
}
