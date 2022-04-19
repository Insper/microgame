using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThaliaLoiola {

    public class Fruit : MonoBehaviour {   
        public GameObject fruitSlicedPrefab;
        public float startForce = 15f;
        private GameManager gm;
        public bool cortou = false;
        Rigidbody2D rb;

        private void Start () {
            rb = GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
            // Debug.Log(GameObject.Find("Watermelon").transform.position);
        }

        void OnTriggerEnter2D (Collider2D col) {
            if (col.CompareTag("Blade")) {
                // Vector3 direction = (col.transform.position - transform.position).normalized;

                // Quaternion rotation = Quaternion.LookRotation(direction);
                GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, transform.rotation);
                // Vector2 direction = col.transform.position;
                
                cortou = true;
                Destroy(slicedFruit, 1f);
                Destroy(gameObject);
            }
        }    
    }
}
