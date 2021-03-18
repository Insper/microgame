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
        speed = Random.Range(minSpeed, maxSpeed);
    }
    void FixedUpdate()
    {
        Vector2 foward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + foward * Time.fixedDeltaTime * speed);
    }
}
