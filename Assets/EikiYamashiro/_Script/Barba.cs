using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EikiYamashiro
{
    public class Barba : MonoBehaviour
    {
        

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter2D(Collider2D other)
        {

            Destroy(gameObject);
        }
    }
}


