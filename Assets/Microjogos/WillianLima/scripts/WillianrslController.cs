using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WillianrslController : BaseMGController
{
    public float moveSpeed = 600f;

    private float mov = 0f;

    public bool gameIsRunning = false;


    // Update is called once per frame
    void Update()
    {
       mov =  Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, mov * Time.fixedDeltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameData.lost = true;
    }

    protected override void StartMicrogame()
    {
        GameManager.Text.text = "Não deixe a bola tocar nas paredes!";
    }

    protected override void Microgame()
    {
        gameIsRunning = true;
    }

    protected override void EndMicrogame()
    {
        if (GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
    }
}
