using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JoaoGuilhermeAlmeida
{
    public class HandSaved : MonoBehaviour
    {

        public bool saved;


        public GameObject ArmSpawner;






        // Start is called before the first frame update
        void Start()
        {
            saved = false;
            ArmSpawner = GameObject.Find("ArmSpawner");
        }

        // Update is called once per frame
        void Update()
        {
            if (saved == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(gameObject);
                    ArmSpawner.GetComponent<ArmSpawner>().amount_saved++;
                }
            }


        }

        void OnTriggerEnter2D(Collider2D col)
        {

            if (col.tag == "Floater")
            {
                saved = true;
            }

        }
        void OnTriggerExit2D(Collider2D col)
        {

            if (col.tag == "Floater")
            {
                saved = false;
            }

        }
    }
}
