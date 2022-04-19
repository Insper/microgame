using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Referencias: 
// https://www.youtube.com/watch?v=ksLin0SxPRo
// https://www.youtube.com/watch?v=xcmYsc2BY-U

public class Player : MonoBehaviour
{

    public float Jump;

    [SerializeField]
    bool isGrounded = false;
    public bool Fail = false;

    Rigidbody2D rigidbody;

    private MicrogameInternal.GameManager gm;

    private void Awake()
    {
        gm = MicrogameInternal.GameManager.GetInstance();
        rigidbody = GetComponent<Rigidbody2D>();
        Invoke(nameof(Begin), 0.5f);
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {

                rigidbody.AddForce(Vector2.up * Jump);
                isGrounded = false;

            }
        }
    }

    void Begin() {

        Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
        gm.StartTimer();
    }

    void EndCheck(){

        if(Fail)
        {
            gm.GameLost();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (isGrounded == false)
        {
            isGrounded = true;
        }
        

        if(collision.gameObject.CompareTag("obstacle"))
        {
            Fail = true;
            Destroy(this.gameObject);
        }
        
    }

}

