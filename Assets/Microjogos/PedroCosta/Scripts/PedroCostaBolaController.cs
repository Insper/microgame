using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedroCostaBolaController : MonoBehaviour
{
    float vel;
    void Start()
    {
        
    }

    public void setVel(float v){
        vel = v;
    }

    public void setColor(Color color){
        GetComponent<SpriteRenderer>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
     transform.position += new Vector3(0, -1, 0) * Time.deltaTime * vel;   
    }
}