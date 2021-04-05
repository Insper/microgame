using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PellizzonController : BaseMGController
{
    public bool startGame = false;
    protected override void EndMicrogame()
    {
        if (GameData.lost)
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
        GameManager.Text.text = "Defenda a princesa!";
    }

    protected override void Microgame()
    {
        startGame = true;
        GameData.lost = false;
    }
}