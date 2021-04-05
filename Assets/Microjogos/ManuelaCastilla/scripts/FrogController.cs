using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FrogController : BaseMGController
{
    Animator animator;
    public Rigidbody2D rb;
    public bool isDead = false;


    // Update is called once per frame
    protected override void EndMicrogame()
    {
        // Mensagens de vítoria ou derrota
        if (GameData.lost)
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
        GameManager.Text.text = "Atravessa o sapinho!";
        animator = gameObject.GetComponent<Animator>();

    }

    protected override void Microgame()
    {
        GameData.lost = true;
    }
    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (GameData.lost == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(rb.position + Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + Vector2.down);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Car")
        {
            Debug.Log("WE LOST!");
            isDead = true;
            animator.SetTrigger("isDead");
        }

        if (col.tag == "finish")
        {
            GameData.lost = false;
        }
    }


}
