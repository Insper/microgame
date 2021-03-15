using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControllerLucianoSoares : BaseMGController
{

    protected override void EndMicrogame()
    {
        Debug.Log("Não Implementada End");
    }

    protected override void StartMicrogame()
    {
        Debug.Log("Não Implementada Start");
    }

    protected override void WinMicrogame()
    {
        Debug.Log("Não Implementada Win");
    }

    private void LateUpdate()
    {
        GameData.lost = true;
    }

    
}
