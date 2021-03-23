using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovment : MonoBehaviour
{
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, vel * Time.deltaTime,0);
        if(GameData.level > 4)
        {
           vel = 13;
        }else if(GameData.level > 2)
        {
           vel = 11;
        }
        
    }
}
