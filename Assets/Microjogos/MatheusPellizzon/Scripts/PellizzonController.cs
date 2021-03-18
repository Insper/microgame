using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PellizzonController : BaseMGController
{

    protected override void EndMicrogame()
    {
        GameData.lost = true;
        Debug.Log("Não Implementada End");
    }

    protected override void StartMicrogame()
    {
        Debug.Log("Não Implementada Start");
    }

    protected override void WinMicrogame()
    {
        GameData.lost = false;
        Debug.Log("Não Implementada Win");
    }

    private void LateUpdate()
    {
        if (GameData.level % 2 == 0) GameData.lost = true;
    }


}