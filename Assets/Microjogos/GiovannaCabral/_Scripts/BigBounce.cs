// Adaptado do canal do Youtube "Nade"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0.0005)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 900f);
        }
    }
}