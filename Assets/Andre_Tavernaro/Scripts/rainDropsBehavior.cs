using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andre_Tavernaro {
    public class rainDropsBehavior : MonoBehaviour
    {
        private Vector3 dir;
        private float speed;
        void Start()
        {   
            speed = 11f;
            dir = new Vector3 (0f,-1f,0f);
        }

        void Update()
        {
            this.transform.position += dir * speed * Time.deltaTime;
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            this.gameObject.SetActive(false);
        }
    }
}