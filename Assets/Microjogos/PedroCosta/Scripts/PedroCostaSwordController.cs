using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedroCostaSwordController : MonoBehaviour
{
    float velocidade = 12 + GameData.level;

    void Start(){
        float scale = 0.5f - GameData.level/10.0f > 0 ? 0.5f - GameData.level/10.0f : 0.1f ;
        transform.localScale = new Vector3(scale, scale, 1);
    }

    private void Update()
    {
    	float inputX = Input.GetAxis("Horizontal");
    	transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("bola"))
            Destroy(collision.gameObject);
    }
}
