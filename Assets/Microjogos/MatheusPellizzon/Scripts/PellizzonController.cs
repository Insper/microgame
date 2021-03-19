using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PellizzonController : BaseMGController
{

    protected override void EndMicrogame()
    {
        if (GameData.lost)
        {

        }
        else
        {

        }
    }

    protected override void StartMicrogame()
    {
        Debug.Log("Não Implementada Start");
    }

    protected override void Microgame()
    {
        Debug.Log("Não Implementada Win");
    }

    private void LateUpdate()
    {
        if (GameData.level % 2 == 0) GameData.lost = true;
    }


}