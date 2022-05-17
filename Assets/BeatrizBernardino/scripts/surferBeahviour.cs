using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BeatrizBernardino
{
    public class surferBeahviour : MonoBehaviour
    {

        public int velocidade = 5;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            float inputX = Input.GetAxis("Horizontal");

            transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
        }
    }
}