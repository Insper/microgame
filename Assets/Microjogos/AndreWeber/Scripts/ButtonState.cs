using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState : MonoBehaviour
{
    private SpriteRenderer spriteState;
    public Sprite button_;
    public Sprite button_pressed;
    public GameObject DeathParticle;
    // Start is called before the first frame update
    public KeyCode key_;
    public string tag;
    public bool active;
    GameObject arrow;
    void Start()
    {
        spriteState = GetComponent<SpriteRenderer>();
        active = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.lost) spriteState.color = Color.red;
        if(Input.GetKeyDown(key_))
        {
            spriteState.sprite = button_pressed;
         
        }
        if(Input.GetKeyUp(key_))
        {
            spriteState.sprite = button_;
        }


        if(Input.GetKeyDown(key_)){
            if(active){
                arrow.SetActive(false);
                Instantiate(DeathParticle, transform.position, Quaternion.identity);
            } else {
                GameData.lost = true;
            }
        } 
    }




    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == tag) {
            active = true;
            arrow = other.gameObject;
            
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == tag) {
            active = false;
            arrow = other.gameObject;
             if (arrow.activeSelf) GameData.lost = true;
            
        }

    }
}
