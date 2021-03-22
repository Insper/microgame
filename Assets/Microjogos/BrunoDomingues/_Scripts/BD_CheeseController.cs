using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BD_CheeseController : MonoBehaviour
{
    public GameObject cheese;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "BD_bun2")
        {
            // Debug.Log("bun2 collected");
            col.gameObject.transform.parent = cheese.transform;
        }
    }
}
