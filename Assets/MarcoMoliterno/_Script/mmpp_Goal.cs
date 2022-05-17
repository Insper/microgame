using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Marcompp {
public class mmpp_Goal : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;

    private mmpp_FlagManager fm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        fm = mmpp_FlagManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Reached");
            fm.reached = true;
        }
    }
}
}