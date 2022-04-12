using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GabriellaCukier {

    public class PlayerBehaviour : MonoBehaviour
    {
        // [Range(1, 15)]
        public float velocidade = 7.0f;
          private Animator anim;

        

        private MicrogameInternal.GameManager gm;

        void Start()
        {
        // gm = GameManager.GetInstance(); 
        gm = MicrogameInternal.GameManager.GetInstance();
        anim = GetComponent<Animator>();
        }

        void Update()
        {
            // if (gm.gameState != GameManager.GameState.GAME) return;

            float inputX = Input.GetAxis("Horizontal");
            transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;

            Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
            pos.x = Mathf.Clamp((float)pos.x, (float)0.04, (float)0.96);
            transform.position = Camera.main.ViewportToWorldPoint(pos);

            // if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            // gm.ChangeState(GameManager.GameState.PAUSE);
            // }
        }


        public void TakeDamage()
        {
            // Destroy(gameObject);     
        }

        //  private void OnTriggerEnter2D(Collider2D collision)
        // {
        //     if (collision.CompareTag("Enemy"))
        //     {
        //         TakeDamage();
        //     //    transform.position = (transform.position - Vector3.right);
        //     Debug.Log("INIMIGO");
        //     }
        // }


        private void OnParticleCollision(GameObject other){
            Debug.Log("collision");
            // anim.SetTrigger("Sink");
            gm.GameLost();
        }

    }
}
