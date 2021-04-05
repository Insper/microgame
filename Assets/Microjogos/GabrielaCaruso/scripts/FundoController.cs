using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundoController : MonoBehaviour
{
    private float offset;
    public Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime / 20.0f);
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}