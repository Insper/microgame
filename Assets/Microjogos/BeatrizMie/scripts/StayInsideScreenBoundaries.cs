using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referências: https://pressstart.vip/tutorials/2018/06/28/41/keep-object-in-bounds.html

public class StayInsideScreenBoundaries : MonoBehaviour
{
    public Camera MainCamera;

    private Vector2 screenBounds;

    private float objectWidth;
    private float objectHeight;

    void Start(){
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    void LateUpdate(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        transform.position = viewPos;
    }
}
