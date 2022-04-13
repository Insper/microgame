using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Marcompp {
public class mmpp_Goal : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;

    private mmpp_GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gm = mmpp_GameManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Reached");
            gm.reached = true;
        }
    }
}
}