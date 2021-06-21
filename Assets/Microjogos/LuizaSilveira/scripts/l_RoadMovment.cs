using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class l_RoadMovment : MonoBehaviour
{
    public Renderer _renderer;
    public float vel;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += vel * Time.deltaTime;
        _renderer.material.SetTextureOffset("_BaseMap", offset);
    }
}
