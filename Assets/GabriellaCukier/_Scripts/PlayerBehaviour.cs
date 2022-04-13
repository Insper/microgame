using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GabriellaCukier {

    public class PlayerBehaviour : MonoBehaviour
    {
        public GameObject instructions;  // Textou das instruçõees        public float velocidade;
        private Animator anim;
        public float velocidade;
        private MicrogameInternal.GameManager gm;
        private GabriellaCukier.LightBorders lb;
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            lb =  GameObject.FindObjectOfType<GabriellaCukier.LightBorders>();
            anim = GetComponent<Animator>();


            // aumenta a velocidade conforme avançam os níveis
            if (gm.ActiveLevel >=4){
                velocidade = 8;  
            }else if (gm.ActiveLevel >= 1){
                velocidade = 7;  
            }else{
                velocidade = 6;  
            }
            Debug.Log($"Velocidade Player: {velocidade}");

            Invoke(nameof(Begin), 0.5f);
        }

            void Begin() {
                instructions.SetActive(false);  // Tira tela de instruções
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
