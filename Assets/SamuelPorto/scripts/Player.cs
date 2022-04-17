using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SamuelPorto
{
    public class Player : MonoBehaviour
    {
        public GameObject instructions;

        public float velocide;

        public bool podeMover = false;

        public Rigidbody2D rb;

        private MicrogameInternal.GameManager gm;

        public GameObject chegada;
        private GameObject _chegada;

        // Start is called before the first frame update
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            rb = gameObject.GetComponent<Rigidbody2D>();

            Invoke(nameof(Begin), 0.5f);
        }

        void Begin() {
            instructions.SetActive(false);

            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);

            _chegada = Instantiate(chegada);

            gm.StartTimer();
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

        void EndCheck() {
            // Se não chegou, perdeu
            if(!_chegada.GetComponent<Chegada>().chegou) {
                gm.GameLost(); 
            } 
        }
    }
}
