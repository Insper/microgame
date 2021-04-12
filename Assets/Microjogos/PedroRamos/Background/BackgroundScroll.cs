using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referências:
//      1. https://www.youtube.com/watch?v=32EIYs6Z18Q
//      2. https://www.youtube.com/watch?v=HrDxnMI7pCc

public class BackgroundScroll : MonoBehaviour
{

    public float speed;

    public Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        if (GameData.level > 0) speed = 0.3f;
        else speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        r.material.mainTextureOffset += new Vector2(speed, 0) * Time.deltaTime;
    }
}