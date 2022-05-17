using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Marcompp {
public class mmpp_SlimeController2D : MonoBehaviour
{
    [Header("Public Variables")]
    public float speed = 5.0f;
    public float jumpforce = 325;


    private Rigidbody2D rb;
    //Vamos salvar o objeto que atingimos com o raycast aqui
    private Vector3 movingDirection;
    private Animator animator;

    [Header("Private Variables")]
    [SerializeField]private Transform groundCheck;
    [SerializeField]private Transform groundCheckII;
    [SerializeField]private float radOCircle;
    [SerializeField]private LayerMask whatIsGround;

    private bool facingRight = true;
    private bool onFloor = false;

    //private Color coloration;
    //GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("groundcheck");
        groundCheckII = gameObject.transform.Find("groundcheckII");

        //gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    private void Update() {
        HandleMovement();
        HandleAnimation();
    }


    private void HandleMovement() {
        onFloor = (Physics2D.OverlapCircle(groundCheck.position,radOCircle,whatIsGround) || Physics2D.OverlapCircle(groundCheckII.position,radOCircle,whatIsGround));
        //Todo
        float hAxis = Input.GetAxis("Horizontal");
        //float vAxis = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(hAxis * speed,rb.velocity.y);
        


        if(Input.GetButtonDown("Jump") && onFloor){
                animator.SetTrigger("Jump");
                rb.AddForce(Vector3.up * jumpforce);
        }

        //rb.MovePosition(transform.position + movingDirection * speed * Time.deltaTime);

        if ((rb.velocity.x > 0.5 && !facingRight) || (rb.velocity.x < -0.5 && facingRight))
        {
            Flip();
        }

        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        if(posicaoViewport.y < 0)
        {
            MicrogameInternal.GameManager.GetInstance().GameLost();
        }
    }

    private void Flip()
    {
        
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        //Vector3 wallCheckpos = wallCheck.position;
        //wallCheck.transform.position = new Vector3(wallCheck.position.x *(-1),wallCheck.position.y,0);
    }


    
    private void HandleAnimation() {
        if (onFloor) {
            animator.SetBool("isAirborne", false);
            if (rb.velocity.x != 0) {
                animator.SetBool("isWalking", true);
            }
            else {
                animator.SetBool("isWalking", false);
            }
        }
        else {
            Debug.Log($"velocity: {rb.velocity.y}");
            
            animator.SetBool("isAirborne", true);
            if (rb.velocity.y < 0) {
                animator.SetBool("isFalling", false);
            }
            else {
                animator.SetBool("isFalling", true);
                animator.ResetTrigger("Jump");
            }
        }
    }

    

    private void OnDrawGizmos()
    {
       Gizmos.DrawSphere(groundCheck.position, radOCircle);
       Gizmos.DrawSphere(groundCheckII.position, radOCircle);
    }
}
}
