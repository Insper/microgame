using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rs_LumberjackController : MonoBehaviour {
    [SerializeField] public rs_Controller controller;

    public int lado = 0;

    void Start() {
        float x = Random.Range(0f, 1f);
        if (x <= 0.5)
        {
            transform.position = new Vector3(2.5f, -3.6f, 0f);
            lado = 1;
        }
    }

    void Update() {
        if (controller.end || !controller.start)
            return;

        float inputX = Input.GetAxis("Horizontal");

        if (inputX < 0)
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
