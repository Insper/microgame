using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JoaoAndrade {

public class Target : MonoBehaviour
    {

        private Rigidbody2D rigidbody;


        private void Awake(){
          rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnMouseOver() {
            if (Input.GetMouseButton(0)){
                FindObjectOfType<GameManager>().DestroyTarget(this);
            }
        }


        // Update is called once per frame
    }
}
