using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour {
    private float xSpeed, ySpeed, xValue, yValue;
    private bool flagStop;
    void Start() {
        flagStop = false;
        // ySpeed = 0.05f;
        xValue = this.transform.position.x;
        yValue = this.transform.position.y;
        

        if (GameData.level > 4) {
            xSpeed = 0.55f;
            ySpeed = 0.18f;
        } else if (GameData.level > 2) {
            xSpeed = 0.45f;
            ySpeed = 0.12f;
        } else {
            xSpeed = 0.35f;
            ySpeed = 0.06f;
        }
    }

    void FixedUpdate() {
        if (flagStop) return;
        if (GameData.level > 4) {
            ySpeed = 0.24f;
        } else if (GameData.level > 2) {
            ySpeed = 0.12f;
        } else {
            ySpeed = 0.06f;
        }
        
        if (this.transform.position.y <= -4.5f) {
            return;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -7.4f) {
            xValue = this.transform.position.x - xSpeed;
        }
        
        if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 7.4f) {
            xValue = this.transform.position.x + xSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            ySpeed *= 3;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            this.transform.Rotate(0f, 0f, 90f);
        }

        if (Input.GetAxisRaw("Jump") != 0){
            flagStop = true;
        }

        yValue = transform.position.y - ySpeed;
        this.transform.position = new Vector3(xValue, yValue, transform.position.z);
    }

}
