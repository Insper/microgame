using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarceloMiguel{
    
    public class Bullet : MonoBehaviour
    {
        public float speed= 20f;
        public Rigidbody2D rb;
        public Vector3 mousePosition;

        public Vector3 directionPoint;

        public GameObject bulletPrefab;
        public GameObject enemyPrefab;

        // Start is called before the first frame update
        void Start()
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            mousePosition = (mousePosition- transform.position).normalized;
            rb.velocity = mousePosition * speed;
            Physics2D.IgnoreCollision(bulletPrefab.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>()); 
            GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("enemy");

            // foreach (GameObject obj in otherObjects) {
            //     Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
            // }

            otherObjects = GameObject.FindGameObjectsWithTag("bullet");

            foreach (GameObject obj in otherObjects) {
                Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
            }
            // Debug.Log(GetComponent<CircleCollider2D>());

        }   

        // Update is called once per frame
        void Update()
        {
            



        }

        void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "wall") {
            ContactPoint2D cp = col.contacts [0];
            mousePosition = Vector3.Reflect(mousePosition, cp.normal);
            rb.velocity = mousePosition*speed;
        }
        // else if(col.gameObject.tag == "enemy"){
        //     Debug.Log("aqui");
        //     Destroy(col.gameObject);
        // }
    }


        // void OnTriggerEnter2D(Collider2D col)
        // {
        //     Debug.Log("aqui");
        //     ContactPoint cp = col.contacts [0];
        //     mousePosition = Vector3.Reflect(mousePosition,cp.normal);
        //     rb.velocity = mousePosition * speed;
        // }

    }

}
