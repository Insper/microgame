using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingArrows : BaseMGController
{
    private float interval_;
    public GameObject spawner;
    // Start is called before the first frame update
    protected override void EndMicrogame()
    {
        // Mensagens de vítoria ou derrota
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
        interval_ = 120;
        
        if(GameData.level > 4)
        {
            interval_ = interval_ / 20f;
        }
        else if(GameData.level > 2)
        {
            interval_ = interval_ / 30f;
        }
        else 
        {
            interval_ = interval_ / 45f;
        }
        
    }

    protected override void Microgame()
    {
       
        spawner.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameData.lost) transform.position -= new Vector3(0f, interval_ * Time.deltaTime, 0f);
        
        
    }


}