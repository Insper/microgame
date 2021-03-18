using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copa : MonoBehaviour
{
    [SerializeField] private Timer timer;

    void Update()
    {
        if (!timer.start || transform.position.y < 1f) return;
        if (Input.GetKeyDown(KeyCode.Space)) transform.position -= new Vector3(0f, 2f, 0f);
    }
}
