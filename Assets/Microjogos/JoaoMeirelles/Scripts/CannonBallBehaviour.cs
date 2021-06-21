using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class CannonBallBehaviour : MonoBehaviour
{
    public bool landed = false;
    public bool landedOut = false;
    public double velocity;
    public float arrasto;
    void Start()
    {
        arrasto = UnityEngine.Random.Range(-1.0f,1.0f);
    }
    public bool getLandingStatus()
    {
        return landed;
    }
    void Update()
    {
        if(landed) return;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x - arrasto * Time.deltaTime,gameObject.GetComponent<Rigidbody2D>().velocity.y - arrasto * Time.deltaTime);
        gameObject.GetComponent<Rigidbody2D>().velocity -= new Vector2(arrasto,0.0f) * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Floor"))
        {
            if(landed) return;
            landedOut = true;
        }
        if(col.gameObject.CompareTag("Target"))
        {
            landed = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,0.0f);
            velocity = 0.0f;
        }
    }
}
