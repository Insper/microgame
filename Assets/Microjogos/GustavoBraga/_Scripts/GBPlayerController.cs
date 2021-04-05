using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBPlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float inputL, inputR, inputX, oldfacingDir, facingDir;
    public bool active = true;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (active)
        {
            HandleInput();
            HandleAnimation();
            rb.MovePosition(transform.position + new Vector3(10f * Time.deltaTime * inputX, 0, 0));
        }
    }

    void HandleInput()
    {
        inputX = 0f;
        if (Input.GetKey("left")) inputX = -1f;
        if (Input.GetKey("right")) inputX = 1f;

        oldfacingDir = facingDir;
        if (inputX > 0) facingDir = inputX;
        else if (inputX < 0) facingDir = inputX;
    }

    void HandleAnimation()
    {
        if (oldfacingDir != facingDir)
        {
            if (inputX < 0) anim.SetTrigger("TurnRight");
            else if (inputX > 0) anim.SetTrigger("TurnLeft");
        }

        if (inputX != 0) anim.SetBool("Running", true);
        else anim.SetBool("Running", false);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "GB_weapon" && active)
        {
            GameData.lost = true;
            active = false;
            anim.SetBool("Dead", true);
        }
    }
}
