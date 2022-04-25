using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucianoSoares {

    // Classe para controlar posição da bolinha
    public class Seguir : MonoBehaviour
    {

        private Vector3 mousePosition;
        public float moveSpeed = 0.1f;
    
        private Rigidbody2D rb2D;

        void Awake()
        {
            rb2D = gameObject.GetComponent<Rigidbody2D>();
        }
    
        void FixedUpdate() {
        
            if (Input.GetMouseButton(0)) {  // verifica se botão clicado

                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

                rb2D.MovePosition(position);  // move o RigidyBody do objeto

            }
    
        }

    }

}
