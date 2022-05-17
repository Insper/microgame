using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HenriqueMualem {
    public class AttachElectricity : MonoBehaviour {
        public GameObject Electricity;
        private GameObject electricity;
        private Vector3 elecCoords = new Vector3(0f, 0f);
        private Animator animator;
        private int run = 0;

        void Start() {
            electricity = Instantiate(Electricity, transform.position, transform.rotation) as GameObject;
            electricity.transform.parent = transform;
            electricity.transform.position = (transform.position + elecCoords);
            animator = electricity.GetComponent<Animator>();
            // laserSmoke.transform.rotation = (Quaternion.Euler(0, 0, -90));
        }

        void Update() {
            electricity.transform.position = (transform.position + elecCoords);
            transform.position = transform.position - new Vector3(0.0f, 0, 0);
            if (run == 1000) {
                run = 0;
                animator.SetBool("TurnElec", true);
            } else animator.SetBool("TurnElec", false);
            run++;
        }
    }
}
