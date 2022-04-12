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
            
        }

        void Spaw(){
            Instantiate(meteoros, new Vector3(Random.Range(-6,6),10,0), Quaternion.identity);
        }
    }
}
