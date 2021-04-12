using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    
    private float min_x = 0;
    private float max_x = 8;

    private float min_y = -3;
    private float max_y = 3.5f;

    public bool gotHit { get; private set; }


    private void OnEnable() {
        float posX = Random.Range(min_x, max_x);
        float posY = Random.Range(min_y, max_y);

        transform.position = new Vector3(posX, posY, 0);
        gotHit = false;
    }

    void Start()
    {
        gotHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Arrow")){
            gotHit = true;
        }
    }
}
