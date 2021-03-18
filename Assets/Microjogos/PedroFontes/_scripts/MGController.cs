using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MGController : BaseMGController
{

    public GameObject faller;

    protected override void EndMicrogame()
    {
        if(GameData.lost)
        {
            GameManager.Text.text = "PUTS!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
        
    }

    protected override void StartMicrogame()
    {
        // Mensagem inicial
        GameManager.Text.text = "Catch!";

    }

    protected override void Microgame()
    {
        

    }

    private void Update()
    {


    }
    
}
