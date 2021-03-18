using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rs_Copa : MonoBehaviour {

    [SerializeField] private rs_Controller controller;

    void Update() {
        if (transform.position.y < 1f)
        {
            if (!controller.end)
                controller.Win();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
            transform.position -= new Vector3(0f, 2f, 0f);
    }
}
