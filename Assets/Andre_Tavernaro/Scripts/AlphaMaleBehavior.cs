using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Andre_Tavernaro {
    public class AlphaMaleBehavior : MonoBehaviour
    {
        private MicrogameInternal.GameManager gm;
        public Animator anim;
        public static float speed;
        private float randomNum;
        public Vector3 dir;
        public static bool isAlive;
        private float count;
        public GameObject GameOverText;
        
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            anim = this.GetComponent<Animator>();

            isAlive = true;
            
            dir = new Vector3 (1f,0f,0f);
            randomNum = Random.Range(0.5f, 3f);

            count = 0.7f;
        }

        void Update()
        {
            count -= Time.deltaTime;
            if(isAlive && count <= 0.01f){
                this.transform.position += speed * dir * Time.deltaTime;

                randomNum -= Time.deltaTime;

                if(randomNum <= 0){
                    dir = dir * -1;
                    randomNum = Random.Range(0.5f, 3f);
                }

                if(this.transform.position.x >= 7){
                    dir = new Vector3 (-1f,0f,0f);
                }
                else if (this.transform.position.x <= -7){
                    dir = new Vector3 (1f,0f,0f);
                }
            } 
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if(isAlive){
                anim.SetTrigger("Death");
            }
            GameOverText.SetActive(true);
            isAlive = false;
        }
    }
}