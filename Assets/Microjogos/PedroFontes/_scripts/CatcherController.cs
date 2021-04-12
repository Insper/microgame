using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherController : MonoBehaviour
{
    Collider2D cldr;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        cldr = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

        cldr.enabled = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            cldr.enabled = true;
            anim.SetBool("grab", true);
        }
        else {
            cldr.enabled = false;
            anim.SetBool("grab", false);
        }
    }
}
