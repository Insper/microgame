using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaBehaviour : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    [SerializeField]
    float jumpForce = 500f;
    float upOrDown;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        upOrDown = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown("space") && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (upOrDown < 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isDown", true);
        }
        else if (upOrDown >= 0 || Input.GetKeyDown("space"))
        {
            anim.SetBool("isDown", false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
            // Encerra o jogo com derrota
        }
    }
}
