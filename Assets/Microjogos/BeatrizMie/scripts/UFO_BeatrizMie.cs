using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referências para a imagem do et: https://favpng.com/png_view/ufo-unidentified-flying-object-extraterrestrial-intelligence-clip-art-png/fPRKC60Q#

public class UFO_BeatrizMie : MonoBehaviour
{
    [Range(1, 10)]
    public float velocity = 5.0f;

    private Vector3 direction;

    void Start()
    {
        float dirX = Random.Range(-3.0f, 3.0f);
        float dirY = Random.Range(-3.0f, 3.0f);

        direction = new Vector3(dirX, dirY).normalized;
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime * velocity;

        if (transform.position.x < -10.0f || transform.position.x > 10.0f) {
            direction = new Vector3(-(direction.x + 0.2f), direction.y);
        }
        if (transform.position.y < -5.0f || transform.position.y > 5.0f) {
            direction = new Vector3(direction.x, -(direction.y + 0.2f));
        }
    }

    // Method called when a collision is triggered
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("UFO"))
        {
            float dirX = Random.Range(-3.0f, 3.0f);
            float dirY = Random.Range(-3.0f, 3.0f);

            direction = new Vector3(dirX, dirY).normalized;
        }
    }
}