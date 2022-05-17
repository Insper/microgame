using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HenriqueMualem {
    public class WireBehavior : MonoBehaviour {
        public bool run = false;
        public bool isOn = false;
        public int wireType = 1;
        public GameObject Electricity;
        private GameObject electricity;
        private Vector3 elecCoords = new Vector3(0.05f, -0.2f);
        private Animator elecAnimator;
        private Animator wireAnimator;
        private SpriteRenderer sprite;

        void Start() {
            sprite = GetComponent<SpriteRenderer>();
            wireAnimator = GetComponent<Animator>();
            wireAnimator.SetInteger("WireType", wireType);
            switch (wireType) {
                case 0:
                    electricity = Instantiate(Electricity, transform.position, transform.rotation) as GameObject;
                    electricity.transform.parent = transform;
                    electricity.transform.position = (transform.position + elecCoords);
                    elecAnimator = electricity.GetComponent<Animator>();
                    break;
                case 1:
                    break;
            }           
        }

        void Update() {
            
            if (isOn) {
                if (run) {
                    run = false;
                    switch (wireType) {
                        case 0:
                            electricity.SetActive(true);
                            elecAnimator.SetBool("TurnElec", true);
                            break;
                        case 1:
                            wireAnimator.SetBool("WireOn", true);
                            break;
                        case 2:
                            wireAnimator.SetBool("WireOn", true);
                            break;
                    }
                }
                else {
                    if (wireType == 0) elecAnimator.SetBool("TurnElec", false);
                }
                
            }
            else {
                if (wireType == 0) {
                    elecAnimator.SetBool("TurnElec", false);
                    electricity.SetActive(false);
                }
                if (wireType == 1 || wireType == 2) wireAnimator.SetBool("WireOn", false);
            }
        }
    }
}
