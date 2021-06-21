using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControllerMichel : MonoBehaviour
{
    private float vel;
    void Start()
    {
        if(GameData.level > 4)
        {
            vel = -15f;
        }
        else if(GameData.level > 2)
        {
            vel = -12f;
        }
        else 
        {
            vel = -10f;
        }
    }

    private void Update() {
        if(!GameData.lost){
            transform.position += new Vector3(vel,0,0)*Time.deltaTime;
        }
    }
}
