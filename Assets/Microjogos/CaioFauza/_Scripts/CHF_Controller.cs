using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHF_Controller : BaseMGController
{
    private Rigidbody2D body;
    Text textLevel;
    
    protected override void StartMicrogame()
    {
        GameManager.Text.text = "Desvie da comida!";
        body = GetComponent<Rigidbody2D>();
        textLevel = GameObject.Find("Level").GetComponent<Text>();
    }

    protected override void Microgame()
    {
    }

    protected override void EndMicrogame()
    {
        GameManager.Text.text =  GameData.lost ? "Você perdeu!" : "Você ganhou!";
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if(viewportPosition.x < 0 || viewportPosition.x > 1) xInput *= -1;
        if(viewportPosition.y < 0 || viewportPosition.y > 1) yInput *= -1;

        int speed = 10;
        textLevel.text = $"Nível de dificuldade: 1";

        if(GameData.level > 3)
        {
            speed = 5;
            textLevel.text = $"Nível de dificuldade: 2";
        } else if(GameData.level > 6)
        {
            speed = 2;
            textLevel.text = $"Nível de dificuldade: 3";
        }

        body.MovePosition(body.position + new Vector2(xInput*speed, yInput*speed) * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {   
            GameData.lost = true;
        }
    }
}
