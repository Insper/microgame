using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBGM : BaseMGController
{
    public GameObject easy, medium, hard, canvas;

    protected override void StartMicrogame()
    {
        GameManager.Text.text = "DODGE";
    }

    protected override void Microgame()
    {
        
    }

    protected override void EndMicrogame()
    {
        if(GameData.lost) GameManager.Text.text = "YOU LOST";
        else GameManager.Text.text = "YOU WON";
    }

    void Start()
    {
        Debug.Log(GameData.level);
        if (GameData.level < 6) easy.SetActive(true);
        else if (GameData.level < 12) medium.SetActive(true);
        else hard.SetActive(true);
    }
}
