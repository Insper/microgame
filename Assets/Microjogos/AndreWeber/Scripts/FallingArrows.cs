using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingArrows : MonoBehaviour
{
    public float interval_;
    // Start is called before the first frame update
    void Start()
    {
        interval_ = interval_ / 60f;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, interval_ * Time.deltaTime, 0f);
        
    }
}