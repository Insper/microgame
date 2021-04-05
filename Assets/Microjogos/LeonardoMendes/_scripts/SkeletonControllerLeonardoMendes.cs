using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonControllerLeonardoMendes : MonoBehaviour
{

    public float velocity;
    public GameObject player;
    
    Animator animator;


    Vector3 direction;
    Vector3 playerPos;

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        direction = new Vector3(0,0,0);
        playerPos = new Vector3(0,0,0);
        isActive = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive){
            animator.SetFloat("Velocity", 1.0f);

            if (GameObject.FindWithTag("Player") != null) 
                playerPos =  GameObject.FindWithTag("Player").transform.position;
                direction = playerPos - transform.position;
                direction.Normalize();
                transform.position += direction * Time.deltaTime * velocity;
                if (direction.x < 0) 
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                else
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        else animator.SetFloat("Velocity", 0f);

    }


        void OnTriggerEnter2D(Collider2D collision)
        {
            animator.Play("skel_attackLeonardoMendes");

        }
}
