using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Vergara{
    public class GameManager : MonoBehaviour{

        private MicrogameInternal.GameManager gm;
        private int[] _progression = {2, 3, 5, 4, 3, 2}; 
        private int _level;
        public GameObject instructions;  // Textou das instruçõees
        // Eggs
        public GameObject Blue;  
        public GameObject Green; 
        public GameObject Orange;
        public GameObject Purple;
        public GameObject Red;
        public GameObject Yellow;
        // Dinos
        public GameObject DinoBlue;
        public GameObject DinoRed;
        public GameObject DinoYellow;
        public GameObject DinoGreen;
        public GameObject Colisor;

        // Start is called before the first frame update
        void Start(){
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            Invoke(nameof(Begin), 0.5f);
            //spawna os dinos
            // spawna o ovo da vez        
        }

        // Update is called once per frame
        void Update(){
        }
        void Begin() {
            instructions.SetActive(false);  // Tira tela de instruções
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);

            // Cria objetos na cena
            //for(int i=0; i<4; i++){
                //par 1
                Vector3 position = new Vector3(5.5f, 2.5f, 0f);
                GameObject par11 = Instantiate(DinoBlue, position, Quaternion.identity, transform);
                Vector3 position2 = new Vector3(6.3f, 2.5f, 0f);
                GameObject par12 = Instantiate(DinoGreen, position2, Quaternion.identity, transform);
                Vector3 coliderPos1 = new Vector3(5.9f, 2.5f, 0f);
                GameObject colider1 = Instantiate(Colisor, coliderPos1, Quaternion.identity, transform);

                //par 2 aka par certo
                Vector3 position3 = new Vector3(5.5f, -2.5f, 0f); //mudar
                GameObject par21 = Instantiate(DinoRed, position3, Quaternion.identity, transform);
                Vector3 position4 = new Vector3(6.3f, -2.5f, 0f); //mudar
                GameObject par22 = Instantiate(DinoBlue, position4, Quaternion.identity, transform);
                Vector3 coliderPos2 = new Vector3(5.9f, -2.5f, 0f);
                GameObject colider2 = Instantiate(Colisor, coliderPos2, Quaternion.identity, transform);
                colider2.GetComponent<Colider>().CorrectPair = true;

                //par 3
                Vector3 position5 = new Vector3(0, 2.5f, 0f); //mudar
                GameObject par31 = Instantiate(DinoGreen, position5, Quaternion.identity, transform);
                Vector3 position6 = new Vector3(0.8f, 2.5f, 0f); //mudar
                GameObject par32 = Instantiate(DinoYellow, position6, Quaternion.identity, transform);
                Vector3 coliderPos3 = new Vector3(0.4f, 2.5f, 0f);
                GameObject colider3 = Instantiate(Colisor, coliderPos3, Quaternion.identity, transform);
                //par 4
                Vector3 position7 = new Vector3(0, -2.5f, 0f); //mudar
                GameObject par41 = Instantiate(DinoYellow, position7, Quaternion.identity, transform);
                Vector3 position8 = new Vector3(0.8f, -2.5f, 0f); //mudar
                GameObject par42 = Instantiate(DinoRed, position8, Quaternion.identity, transform);
                Vector3 coliderPos4 = new Vector3(0.4f, -2.5f, 0f);
                GameObject colider4 = Instantiate(Colisor, coliderPos4, Quaternion.identity, transform);
           // }
            Vector3 positionEgg = new Vector3(-5f, 0f, 0f); //mudar
            GameObject egg = Instantiate(Purple, positionEgg, Quaternion.identity, transform);

            gm.StartTimer(); 
        }

        void EndCheck() {
          gm.GameLost(); 
        }
    }
}