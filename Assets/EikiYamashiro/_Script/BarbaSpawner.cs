using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EikiYamashiro
{
    public class BarbaSpawner : MonoBehaviour
    {
        public GameObject instructions;  // Textou das instruçõees
        public GameObject Barba;
        private MicrogameInternal.GameManager gm; 

        void makeMustache(int max_i,int max_j,float x,float y)
        {
            for(int i = 0; i < max_i; i++)
            {
                for(int j = 0; j < max_j; j++){
                Vector3 posicao = new Vector3(x - 0.1f*i,y -0.1f * j);
                Instantiate(Barba, posicao, Quaternion.identity, transform);
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            Debug.Log($"ActiveLevel: {gm.ActiveLevel}");
            // Bigodinho Fino
            if (gm.ActiveLevel <= 0) {
                makeMustache(18,2,0.75f,-0.2f);
                makeMustache(20,2,0.85f,-0.3f);
                makeMustache(22,2,0.95f,-0.4f);
            }

            // Cavanhaque
            else if (gm.ActiveLevel <= 1) {
                makeMustache(18,2,0.75f,-0.2f);
                makeMustache(20,2,0.85f,-0.3f);
                makeMustache(22,2,0.95f,-0.4f);

                makeMustache(4,14,1.0f,-0.4f);
                makeMustache(4,14,-1.0f,-0.4f);

                makeMustache(8,2,0.2f,-2.4f);
                makeMustache(16,2,0.65f,-2.2f);
                makeMustache(18,4,0.75f,-2.0f);
                makeMustache(20,3,0.85f,-1.8f);
                makeMustache(22,2,0.95f,-1.6f);
                makeMustache(22,2,0.95f,-1.4f);
                
            }

            // // Barba do Emil
            else {
                makeMustache(18,2,0.75f,-0.2f);
                makeMustache(20,2,0.85f,-0.3f);
                makeMustache(22,2,0.95f,-0.4f);

                makeMustache(4,16,1.0f,-0.2f);
                makeMustache(4,14,1.2f,-0.2f);
                makeMustache(4,12,1.4f,-0.2f);
                makeMustache(4,8,1.6f,-0.2f);
                makeMustache(4,6,1.8f,-0.2f);

                makeMustache(4,16,-1.0f,-0.2f);
                makeMustache(4,14,-1.2f,-0.2f);
                makeMustache(4,12,-1.4f,-0.2f);
                makeMustache(4,8,-1.6f,-0.2f);
                makeMustache(4,6,-1.8f,-0.2f);

                makeMustache(8,2,0.2f,-2.4f);
                makeMustache(16,2,0.65f,-2.2f);
                makeMustache(18,4,0.75f,-2.0f);
                makeMustache(20,3,0.85f,-1.8f);
                makeMustache(22,2,0.95f,-1.6f);
                makeMustache(22,2,0.95f,-1.4f);
            }

            Invoke(nameof(Begin), 0.5f);
        }

        void Begin() {
            instructions.SetActive(false);  // Tira tela de instruções
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer();
        }

        void EndCheck() {

            // Se sobrou algum pelo, perde
            if(transform.childCount >= 1) {
                gm.GameLost(); 
            } 

        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}