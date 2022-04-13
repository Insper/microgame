using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AnaClaraCarneiro {
    public class Meteoros : MonoBehaviour
    {
        public float delay = 0.1f;
        public GameObject meteoros;
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("Spaw", delay, delay);
        }

        // Update is called once per frame
        void Update()
        {
            // if (transform.position.y <= -6.0f && GameObject.Find("Meteor(Clone)")){
            //     Destroy(meteoros);
            // }
        }

        void Spaw(){
            Instantiate(meteoros, new Vector3(Random.Range(-6,6),6,0), Quaternion.identity);
        }
    }
}
