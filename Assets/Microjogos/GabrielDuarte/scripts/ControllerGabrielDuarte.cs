using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerGabrielDuarte : BaseMGController
{
    public GameObject ovo0;
    public GameObject ovo1;
    public GameObject ovo2;
    public GameObject ovo3;
    public GameObject ovo4;
    public GameObject ovo5;

    public int clicked, objetivo;
    
    protected override void EndMicrogame()
    {
        if(GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
        
    }

    protected override void StartMicrogame()
    {
        GameManager.Text.text = "Quebre o Ovo!";
        ovo0.SetActive(true);
        clicked = 0;

        if(GameData.level > 4)
        {
            objetivo = 30;
        }
        else if(GameData.level > 2)
        {
            objetivo = 22;
        }
        else 
        {
            objetivo = 10;
        }

        GameData.lost = true;
    }

    protected override void Microgame()
    {
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clicked += 1;
        }
        
        float porcent = (float)clicked/objetivo;

        if (porcent >= 0.15f && porcent < 0.3f) {
            ovo0.SetActive(false);
            ovo1.SetActive(true);
        } 
        if (porcent >= 0.3f && porcent < 0.45f) {
            ovo1.SetActive(false);
            ovo2.SetActive(true);
        } 
        if (porcent >= 0.60f && porcent < 0.75f) {
            ovo2.SetActive(false);
            ovo3.SetActive(true);
        } 
        if (porcent >= 0.90f && porcent < 1.0f) {
            ovo3.SetActive(false);
            ovo4.SetActive(true);
        } 

        if (clicked >= objetivo) {
            GameData.lost = false;
            ovo4.SetActive(false);
            ovo5.SetActive(true);
        }

    }
    
}
