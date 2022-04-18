using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Andre_Tavernaro {
    public class UmbrellaBehavior : MonoBehaviour
    {
        private Vector3 dir;
        public static float speed;
        public static Vector3 scale;

        void Start()
        {
            this.transform.localScale = scale;
        }

        void Update()
        {
            if(Input.GetAxisRaw("Horizontal") == 1){
                dir = new Vector3 (1f,0f,0f);
            }
            else if (Input.GetAxisRaw("Horizontal") == -1){
                dir = new Vector3 (-1f,0f,0f);
            }
            else{
                dir = new Vector3 (0f,0f,0f);
            }
            this.transform.position += speed * dir * Time.deltaTime;
        }
    }
}