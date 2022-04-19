using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaisSilva{
    public class Martelo : MonoBehaviour
    {
        private Animator anim;

        public float Speed;

        //private LaisSilva.GameManager gm;
        public int pontos = 0;
        

        void Start()
        {
            anim = GetComponent<Animator>();
            //gm = LaisSilva.GameManager.GetInstance();
            
        }

        void Update()
        {
            Move();
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("Bater", true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("Bater", false);
            }
        }

        void Move()
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10.0f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Toupera"))
            {
                pontos++;
                
            }
        }
    }
}
