using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SamuelPorto
{
    public class Player : MonoBehaviour
    {
        public float velocide;

        public bool podeMover = false;

        public Rigidbody2D rb;

        // Start is called before the first frame update
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (podeMover == true)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.velocity = new Vector2(0, 1 * velocide * Time.deltaTime);
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    rb.velocity =
                        new Vector2(0, -1 * velocide * Time.deltaTime);
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    rb.velocity =
                        new Vector2(-1 * velocide * Time.deltaTime, 0);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    rb.velocity = new Vector2(1 * velocide * Time.deltaTime, 0);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Wall")
            {
                podeMover = true;
            }
        }

        void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.tag == "Wall")
            {
                podeMover = false;
            }
        }
    }
}
