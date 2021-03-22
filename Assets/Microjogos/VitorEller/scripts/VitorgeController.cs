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
        }
    }

    protected override void StartMicrogame()
    {
    }

    protected override void Microgame()
    {
        GameManager.Text.text = GameData.GetTime().ToString();
    }

    private void LateUpdate()
    {
        if (GameData.level %2 == 0) GameData.lost = true;
    }

    
}
