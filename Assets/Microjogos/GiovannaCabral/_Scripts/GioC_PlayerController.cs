// Adaptado do canal do Youtube "Nade"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GioC_PlayerController : BaseMGController
{
    private Rigidbody2D rb;
    private float moveInput;
    private float speed = 10f;
    public GameObject platform;
    public GameObject player;
    private float top = 0.0f;

    protected override void EndMicrogame()
    {
        // Mensagens de vítoria ou derrota
        if(GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
        
    }

    protected override void StartMicrogame()
    {
        // Mensagem inicial
        GameManager.Text.text = "Não caia!";
        
        // Raquete é escalada conforme o nível
        if(GameData.level > 4)
        {
            speed = 60f;
        }
        else if(GameData.level > 2)
        {
            speed = 40f;
        }
        else 
        {
            speed = 10f;
        }
        rb.velocity = new Vector2(0.0f, 0.0f);
    }

    protected override void Microgame()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(moveInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }else{
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if(rb.velocity.y > 0 && transform.position.y > top){
            top = transform.position.y;
        }
        if(transform.position.y+30 < top)
        {
            GameData.lost = true;
        }
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}
