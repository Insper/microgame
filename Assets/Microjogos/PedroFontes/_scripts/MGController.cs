using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MGController : BaseMGController
{

    public GameObject faller;

    public bool pega = true;
    float sepa;

    void Start(){
        sepa = Random.Range(0f, 1f);
        
        Debug.Log(sepa);

        if (sepa < 0.5f){
            pega = false;
        }
    }

    protected override void EndMicrogame()
    {

        faller.GetComponent<Collider2D>().enabled = false;

        if(GameData.lost)
        {
            GameManager.Text.text = "PUTS!";
        }
        else
        {
            GameManager.Text.text = "NICE!";
        }
        
    }

    protected override void StartMicrogame()
    {
        // Mensagem inicial
        if (pega) GameManager.Text.text = "Catch!";
        else GameManager.Text.text = "Don't!";

    }

    protected override void Microgame()
    {
        

    }

    private void Update()
    {


    }
    
    
}
