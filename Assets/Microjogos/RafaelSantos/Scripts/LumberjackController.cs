using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackController : MonoBehaviour
{
    [SerializeField] private Timer timer;

    public int lado = 0;
    public Timer t;

    void Start()
    {
        t = timer;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        if (inputX != 0) timer.start = true;

        if (!timer.start) return;


        if(inputX < 0)
        {
            transform.position = new Vector3(-2.5f, -3.6f, 0f);
            lado = 0;
        }
        else if (inputX > 0)
        {
            transform.position = new Vector3(2.5f, -3.6f, 0f);
            lado = 1;
        }
    }
}
