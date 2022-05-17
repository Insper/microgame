using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gabrielamb2{
public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            if(canBePressed){
                Destroy(gameObject);
                Gabrielamb2.GameManager.instance.NoteHit();
                // Gabrielamb2.GameManager.NoteHit();
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            
            canBePressed = true;
               
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            
            canBePressed = false;
            Gabrielamb2.GameManager.instance.NoteMissed();
            // MicrogameInternal.GameManager.GetInstance().GameLost();
        }
    }
}
}

