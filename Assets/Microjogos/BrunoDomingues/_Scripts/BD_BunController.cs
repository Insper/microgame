using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BD_BunController : MonoBehaviour
{
    public GameObject bun1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "BD_patty")
        {
            // Debug.Log("patty collected");
            col.gameObject.transform.parent = bun1.transform;
        }
    }
}
