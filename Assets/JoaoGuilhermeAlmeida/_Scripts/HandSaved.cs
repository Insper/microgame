using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JoaoGuilhermeAlmeida {
    public class HandSaved : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            print("AAAAAAAAAA");
        }

        void OnCollisionEnter2D(Collision2D col){
            print(col.collider.tag);
            if (Input.GetKeyDown("space")){
                if(col.collider.tag == "Floater"){
                    print("Saved");
                }
            }

        }
    }
}
