using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AnaClaraCarneiro {
    public class Meteoros : MonoBehaviour
    {
        private float delay;
        public GameObject meteoros;
        public bool perdeu = false;

        private GameObject meteoro;
        private GameObject meteoro_clone;

        private MicrogameInternal.GameManager gm;
        private int _level;
        
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            
            if(_level == 0){
                delay = 2.0f;
            }else if(_level == 1){
                delay = 1.0f;
            }else{
                delay = 0.5f;
            }

            InvokeRepeating("Spaw", delay, delay);
            
        }

        void Update()
        {
            
        }

        void Spaw(){
            Instantiate(meteoros, new Vector3(Random.Range(-6,6),6,0), Quaternion.identity);
        }

        void OnCollisionEnter2D(Collision2D collision){
            if (collision.gameObject.tag == "Player"){
                perdeu = true;
            }
        }
    }
}
