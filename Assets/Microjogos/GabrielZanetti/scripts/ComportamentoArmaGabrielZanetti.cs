using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoArmaGabrielZanetti : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cano;
    public GameObject tiro;
    void Start()
    {
        
    }

    public void Atira() 
    {
        Debug.Log("Não Implementada Atirar");
        Instantiate(tiro, cano.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
