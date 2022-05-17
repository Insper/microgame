using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Andre_Tavernaro {
    public class rainSpawnerBehavior : MonoBehaviour
    {
        public GameObject rainDrops;
        private Vector3 pos;
        private GameObject tempObject;

        void Start()
        {
            InvokeRepeating("SpawnRainDropLine", 0.5f, 0.3f);
        }

        void SpawnRainDropLine(){
            for (int i = - 11; i < 11; i++){
                float randomNum = Random.Range(5f, 5.7f);
                pos = new Vector3(i,randomNum,this.transform.position.z);
                tempObject = Instantiate(rainDrops,pos,Quaternion.identity);
                tempObject.transform.SetParent(this.transform);
            }
        }
    }
}