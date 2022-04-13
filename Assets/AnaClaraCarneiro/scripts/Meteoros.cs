using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AnaClaraCarneiro {
    public class Meteoros : MonoBehaviour
    {
        public float delay = 0.1f;
        public GameObject meteoros;
        public bool perdeu = false;

        private GameObject meteoro;
        private GameObject meteoro_clone;
        
        void Start()
        {
            InvokeRepeating("Spaw", delay, delay);
        }

        void Update()
        {
            meteoro = GameObject.Find("Meteor");
            meteoro_clone = GameObject.Find("Meteor(Clone)");

            if (transform.position.y <= -6.0f && (gameObject == meteoro || gameObject == meteoro_clone)){
                // print("meteoros");
                // Destroy(meteoros);
            }
        }

        void Spaw(){
            Instantiate(meteoros, new Vector3(Random.Range(-6,6),6,0), Quaternion.identity);
        }

        void OnCollisionEnter2D(Collision2D collision){
            if (collision.gameObject.tag == "Player"){
                perdeu = true;
            }
        }
    }
}
