using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gabrielfz_Boundaries : MonoBehaviour
{
    private Vector2 screen_bounds;
    // Start is called before the first frame update
    void Start() {
        screen_bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public bool IsObjectOutOfBounds(Vector3 object_position) {
        if (object_position.x > screen_bounds.x || object_position.x < screen_bounds.x*-1) {
            return true;
        } 
        else if(object_position.y > screen_bounds.y || object_position.y < screen_bounds.y*-1) {
            return true;
        }

        return false;

    }
}
