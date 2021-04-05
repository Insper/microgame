using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float speed = 1f;
    // Update is called once per frame

    void Start()
    {
        Debug.Log(GameData.level);
        if (GameData.level > 4)
        {
            speed = Random.Range(5f, 6f);
        }
        if (GameData.level > 2)
        {
            speed = Random.Range(4f, 5f);
        }
        else
        {
            speed = Random.Range(3f, 4f);
        }
    }
    void FixedUpdate()
    {

        Vector2 foward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + foward * Time.fixedDeltaTime * speed);
    }
}
