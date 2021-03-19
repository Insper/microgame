using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MGController : BaseMGController
{

    public GameObject faller;

    public bool pega = true;

    void Start(){
        if (Random.Range(0f, 1f) > 0.4f){
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
