using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBWeaponController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bC;
    public bool active = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bC = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (active) 
        {
            active = false;
            bC.enabled = false;
            rb.isKinematic = true;
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
