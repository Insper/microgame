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
        private GabriellaCukier.LightBorders lb;
        void Start()
        {
        gm = MicrogameInternal.GameManager.GetInstance();
        lb =  GameObject.FindObjectOfType<GabriellaCukier.LightBorders>();
        anim = GetComponent<Animator>();
        gm.StartTimer(); 
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

            // Debug.Log("Collider bound Minimum : " + lb.m_Min);
            // Debug.Log("Collider bound Maximum : " + lb.m_Max);
        }


        private void OnParticleCollision(GameObject other){
            // Debug.Log("collision");
            // anim.SetTrigger("Sink");
            if (!(transform.position.x > lb.m_Min.x && transform.position.x < lb.m_Max.x))
                gm.GameLost();
        }

    }
}
