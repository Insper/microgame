// PARTE DESTE CÓDIGO FOI IMPORTADA DA DOCUMENTAÇÃO DO UNITY E PODE SER ENCONTRADA EM: https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerWarlenRodrigues : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter(Collider other)
    {
        //This will fire
        Debug.Log("trigger enter!");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(-1f, 0, 0);
    }
}
