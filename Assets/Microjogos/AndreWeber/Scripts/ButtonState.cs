using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState : MonoBehaviour
{
    private SpriteRenderer spriteState;
    public Sprite button_;
    public Sprite button_pressed;
    // Start is called before the first frame update
    public KeyCode key_;
    void Start()
    {
        spriteState = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key_))
        {
            spriteState.sprite = button_pressed;
        }
        if(Input.GetKeyUp(key_))
        {
            spriteState.sprite = button_;
        } 
    }
}
