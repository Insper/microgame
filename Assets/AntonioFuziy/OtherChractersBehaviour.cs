using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AntonioFuziy {
    public class OtherChractersBehaviour : MonoBehaviour {
        [Range(1, 15)]
        private MicrogameInternal.GameManager gm;
        public int[] _speed = {5, 5, 6, 7, 8, 8};

        private Vector3 direction;
        private int current_speed;

        void Start(){
            gm = MicrogameInternal.GameManager.GetInstance();
            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            current_speed = _speed[gm.ActiveLevel];

            direction = new Vector3(dirX, dirY).normalized;
        }

        void Update(){
            transform.position += direction * Time.deltaTime * current_speed;
            Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

            if( viewportPosition.x < 0 || viewportPosition.x > 1 ){
                direction = new Vector3(-direction.x, direction.y);
            }
            if( viewportPosition.y < 0 || viewportPosition.y > 1 ){
                direction = new Vector3(direction.x, -direction.y);
            }
        }
        private void OnMouseOver() {
            if(Input.GetMouseButton(0)) {
                MicrogameInternal.GameManager.GetInstance().GameLost();
            }
        }
         
        void OnTriggerEnter2D(Collider2D col){
            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            direction = new Vector3(dirX, dirY).normalized;
        }
    }
}