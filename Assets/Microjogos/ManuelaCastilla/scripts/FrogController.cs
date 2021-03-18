using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogController : MonoBehaviour
{

    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        // float yInput = Input.GetAxisRaw("Vertical");
        // float xInput = Input.GetAxisRaw("Horizontal");
        // Thrust(xInput, yInput);
        // if (yInput != 0 || xInput != 0)
        // {
        //     animator.SetFloat("Velocity", 1.0f);
        // }
        // else
        // {
        //     animator.SetFloat("Velocity", 0.0f);
        // }

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
