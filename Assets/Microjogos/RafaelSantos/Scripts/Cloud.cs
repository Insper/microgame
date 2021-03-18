using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private Vector3 speed;

    void Start()
    {
        speed = new Vector3(Random.Range(0.002f, 0.007f), 0, 0);
    }

    void Update()
    {
        transform.position += speed;
        if (transform.position.x > 11) transform.position = new Vector3(-12, Random.Range(-6, 6), 0);
    }
}
