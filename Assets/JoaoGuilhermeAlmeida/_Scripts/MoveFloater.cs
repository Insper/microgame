using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JoaoGuilhermeAlmeida {
    public class MoveFloater : MonoBehaviour
    {
        private Rigidbody2D rb;

        public int speed = 5;

        private Vector3 direcao;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            direcao = new Vector3(inputX, inputY).normalized;

            transform.position += direcao * Time.deltaTime * speed;

            
        }
    }
}
