using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppleController : MonoBehaviour
{
    float x;
    float y;
    Random rnd = new Random();
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        x = Random.Range(-5.0f, 5.0f);
        y= Random.Range(-5.0f, 5.0f);
        transform.position += new Vector3(x,y, 0);

    }
}
