using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    Rigidbody2D rb;

    private bool hitTarget = false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if (hitTarget == false)
        {
            rotate();

            if (gotOutOfScreen())
            {
                Destroy(gameObject);
            }
        }
        
    }

    void rotate() {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Target"))
        {
            hitTarget = true;
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
        } else if (other.gameObject.CompareTag("Floor"))
        {
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
        }

    }

    bool gotOutOfScreen(){
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        return posicaoViewport.x < 0 || posicaoViewport.x > 1 || posicaoViewport.y > 1 || posicaoViewport.y < 0;
    }
}
