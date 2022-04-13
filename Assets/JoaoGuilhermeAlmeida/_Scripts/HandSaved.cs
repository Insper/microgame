using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JoaoGuilhermeAlmeida
{
    public class HandSaved : MonoBehaviour
    {

        public bool saved;



        // Start is called before the first frame update
        void Start()
        {
            saved = false;
            // gm = GameObject.Find("MainCamera").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (saved == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(gameObject);
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
