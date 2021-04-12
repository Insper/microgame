using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMichel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Obstacle")){
            GetComponent<Animator>().SetTrigger("Damage");
            GameData.lost = true;
        }
    }
}
