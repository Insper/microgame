using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MeuController : BaseMGController
{

    protected override void EndMicrogame()
    {
        Debug.Log("Não Implementada End");
    }

    protected override void WinMicrogame()
    {
        Debug.Log("Não Implementada Win");
    }

    private void LateUpdate()
    {
        //if (GameData.level == 5) GameData.lost = true;
    }

    
}
