using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseController : MonoBehaviour
{
    public GameObject cheese;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bun2")
        {
            // Debug.Log("bun2 collected");
            col.gameObject.transform.parent = cheese.transform;
        }
    }
}
