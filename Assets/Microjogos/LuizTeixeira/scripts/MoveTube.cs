using UnityEngine;
using System.Collections;

public class MoveTube : MonoBehaviour
{
    public float tubeSpeed;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.level > 4)
        {
            tubeSpeed = 15;
        }
        else if (GameData.level > 2)
        {
            tubeSpeed = 10;
        }
        else
        {
            tubeSpeed = 5;
        }

        transform.position += Vector3.left * tubeSpeed * Time.deltaTime;
    }
}
