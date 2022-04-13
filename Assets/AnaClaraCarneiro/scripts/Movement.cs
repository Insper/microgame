using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnaClaraCarneiro {
    public class Movement : MonoBehaviour
    {
        public float speed = 0.5f;
        private Animator animator;
        private Vector3 direction;
        private Rigidbody2D rb;
        int facingLeft = 0;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleAnimation();
            HandleMovement();
            // direction = new Vector3(Input.GetAxis("Horizontal"), 0).normalized;
            // transform.position += new Vector3(Input.GetAxis("Horizontal")*velocity,0,0);

            if (transform.position.x <= -8.4f){
                transform.position = new Vector3(-8.4f, -3.5f, 0);
            }

            if (transform.position.x >= 8.4f){
                transform.position = new Vector3(8.4f, -3.5f, 0);
            }
            
        }

        void OnCollisionEnter(){
            Destroy(gameObject);
        }

        private void HandleMovement()
        {
            float hAxis = Input.GetAxis("Horizontal");
            direction = new Vector3(hAxis, 0).normalized;

            if (direction.x < 0 && facingLeft == 0)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingLeft = 1;
            }
            if (direction.x > 0 && facingLeft == 1)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingLeft = 0;
            }
            Vector3 vel = new Vector3(0, rb.velocity.y, 0);
            rb.velocity = (direction * speed) + vel;
        }

        private void HandleAnimation()
        {

            if (direction != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}