using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallerController : MonoBehaviour
{
    public GameObject mainController;

    void OnTriggerEnter2D(Collider2D col){

        if (col.tag == "floor" && mainController.GetComponent<MGController>().pega == true) {
            GameData.lost = true;
        }

        else if (col.tag == "catcher" && mainController.GetComponent<MGController>().pega == false) {
            GameData.lost = true;
        }

    }

}
