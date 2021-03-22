using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : SteerableBehaviour
{

    private int level;

    // Start is called before the first frame update
    void Start()
    {
        level = GameData.level/10;
    }

    // Update is called once per frame
    void Update()
    {
        Thrust(2*(level+1),level);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("VitorgePlayer")) return;
        if (collision.CompareTag("VitorgeTarget")) {
            Destroy(collision.gameObject); 
        }
        Destroy(gameObject);
    }
}
