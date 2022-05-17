using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GabriellaCukier {

    public class FishBehaviour : MonoBehaviour
    {

            private float velocidade;
            private MicrogameInternal.GameManager gm;

            void Start()
            {
                gm = MicrogameInternal.GameManager.GetInstance();

                // aumenta a velocidade conforme avançam os níveis
                if (gm.ActiveLevel >=4){
                    velocidade = 8;  
                }else{
                    velocidade = 6;  
                }

                Destroy(gameObject,3f);
            }

            void Update()
            {

                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * velocidade;
            
            }
    }
}