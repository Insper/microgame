using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BD_BurgerController : MonoBehaviour
{
    public GameObject burger;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "BD_cheese")
        {
            // Debug.Log("cheese collected");
            col.gameObject.transform.parent = burger.transform;
        }
    }
}
