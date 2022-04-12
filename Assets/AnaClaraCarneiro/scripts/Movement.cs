using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnaClaraCarneiro {
    public class Movement : MonoBehaviour
    {
        public float velocity = 0.5f;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal")*velocity,0,0);

            if (transform.position.x <= -8.4f){
                transform.position = new Vector3(-8.4f, -3, 0);
            }

            if (transform.position.x >= 8.4f){
                transform.position = new Vector3(8.4f, -3, 0);
            }
            
        }

        void OnCollisionEnter(){
            Destroy(gameObject);
        }
    }
}