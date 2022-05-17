using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EikiYamashiro
{
    public class MaquininhaDeBarbear : MonoBehaviour
    {

        public AudioSource audio;
        // Start is called before the first frame update
        void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
        }

        void OnTriggerEnter2D(Collider2D other)
        {

            audio.Play();
        }
        
    }
}