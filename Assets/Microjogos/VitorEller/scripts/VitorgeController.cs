using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class VitorgeController : BaseMGController
{

    protected override void EndMicrogame()
    {
        GameObject target = GameObject.FindGameObjectWithTag("VitorgeTarget");
        if (target) {
            GameData.lost = true;
            GameManager.Text.text = "Você perdeu!";
        } else {
            GameManager.Text.text = "Você ganhou!";
        }
    }

    protected override void StartMicrogame()
    {
        GameManager.Text.text = "Atire para\ndestruir o prato!";
    }

    protected override void Microgame()
    {
    }

    
}
