using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PedrohepfController : BaseMGController
{

    protected override void EndMicrogame()
    {
        Debug.Log("Não Implementada End");
    }

    protected override void StartMicrogame()
    {
        Debug.Log("Não Implementada Start");
    }

    protected override void Microgame()
    {
        Debug.Log("Não Implementada");
        GameManager.Text.text = GameData.GetTime().ToString();
    }

    private void LateUpdate()
    {
        if (GameData.level %2 == 0) GameData.lost = true;
    }

    
}
