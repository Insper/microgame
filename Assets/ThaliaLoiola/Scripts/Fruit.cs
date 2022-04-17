using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{   
    public GameObject fruitSlicedPrefab;
    public float startForce = 15f;
    int pontuacao = 0;
    Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Blade") {
            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            // GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            pontuacao++;
            Debug.Log( pontuacao);
            Destroy(slicedFruit, 1f);
            Destroy(gameObject);
        }
    }    
}
