using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    [SerializeField] private LumberjackController player;

    private int k = 700;
    private int y = 100;

    public bool machadado = false;

    private void Hit(int lado)
    {
        transform.position -= new Vector3(0f, 2f, 0f);

        if (machadado || transform.position.y > -4) return;
        Destroy(gameObject, 0.2f);

        machadado = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().enabled = false;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.gravityScale = 1f;
        if(lado == 0)
            rb.AddForce(new Vector2(Random.Range(1f, 2f) * k, y));
        else
            rb.AddForce(new Vector2(Random.Range(-2f, -1f) * k, y));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) player.t.start = true;

        if (!player.t.start) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hit(player.lado);
        }
    }
}
