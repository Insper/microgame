using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HenriqueMualem {
    public class SwitchBehavior : MonoBehaviour {
        public bool isOn = false;
        private SpriteRenderer sprite;
        private float nextChange = 0.0f;
        private float delay = 0.2f;
        private Animator switchAnimator;

        void OnMouseOver() {
            if (Time.time > nextChange) {
                if (Input.GetMouseButton(0) && !isOn) {
                    nextChange = Time.time + delay;
                    isOn = true;
                } 
                else if (Input.GetMouseButton(0) && isOn) {
                    nextChange = Time.time + delay;
                    isOn = false;
                }
            }
        }

        void Start() {
            sprite = GetComponent<SpriteRenderer>();
            switchAnimator = GetComponent<Animator>();
        }

        void Update() {
            if (isOn) {
                // sprite.color = new Color(0, 255, 0, 255);
                switchAnimator.SetBool("SwitchOn", true);
                
            }
            else {
                // sprite.color = new Color(255, 0, 0, 255);
                switchAnimator.SetBool("SwitchOn", false);
            }
        }
    }
}
