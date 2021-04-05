using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referências para a imagem do player: https://www.gratispng.com/png-xlgs6i/

public class PlayerController_BeatrizMie : MonoBehaviour
{
    [Range(1, 10)]
    public float velocity;

    void Update() 
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * velocity;
    }

    // Method called when a collision is triggered
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("UFO"))
        {
            Destroy(gameObject);
            GameData.lost = true;
        }
    }
}