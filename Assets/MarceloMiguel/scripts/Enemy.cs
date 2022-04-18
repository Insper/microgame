using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarceloMiguel
{

    public class Enemy : MonoBehaviour
    {
        public AudioClip saw;
        public Renderer rend;

        // Start is called before the first frame update

        void Start()
        {
            rend = GetComponent<Renderer>();

            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = saw;

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter2D(Collider2D other)
        {
            
            GetComponent<AudioSource>().Play();

            rend.enabled = false;

            Destroy(gameObject,GetComponent<AudioSource>().clip.length);

        }
    }
}