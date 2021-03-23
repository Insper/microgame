using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class CannonBallBehaviour : MonoBehaviour
{
    public double velocity;
    Vector3 direction;
    public GameObject cannon;
    public float angle;
    ChargeBarController ComponenteCanhao;
    float lastFrameSec;
    float arrasto;
    bool landed;
    // Start is called before the first frame update
    void Start()
    {
        landed = false;
        lastFrameSec = Time.time;
        ComponenteCanhao = cannon.GetComponent<ChargeBarController>();
        arrasto = UnityEngine.Random.Range(-1.0f,1.0f);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((float)ComponenteCanhao.charge/2, (float)ComponenteCanhao.charge/2);
        gameObject.GetComponent<Rigidbody2D>().rotation = ComponenteCanhao.angle;
    }

    bool isOut()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        if(transform.position.x > stageDimensions.x | transform.position.x < -stageDimensions.x | transform.position.y > stageDimensions.y)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(landed) return;
        if(isOut()) Destroy(gameObject);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x - arrasto * Time.deltaTime,gameObject.GetComponent<Rigidbody2D>().velocity.y - arrasto * Time.deltaTime);
        velocity -= arrasto * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Floor"))
        {
            if(landed) return;
            Destroy(gameObject);
        }
        if(col.gameObject.CompareTag("Target"))
        {
            landed = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,0.0f);
            velocity = 0.0f;
            direction = new Vector3(0.0f,0.0f).normalized;
            Debug.Log(direction + " " + velocity);
        }
    }
}
