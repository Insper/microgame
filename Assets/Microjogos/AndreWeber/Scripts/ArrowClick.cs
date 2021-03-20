using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClick : MonoBehaviour
{
    public bool pressed;
    public KeyCode key_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key_)){
            if(pressed){
                gameObject.SetActive(false);
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Buttons") {
            pressed = true;
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Buttons") {
            pressed = false;
            
        }

    }
}
