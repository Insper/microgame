using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hr_GameController : BaseMGController
{
    protected override void StartMicrogame()
    {
        Debug.Log("Inicio do Jogo");
    }

    protected override void Microgame()
    {
        Debug.Log("Jogo Principal");
    }

    protected override void EndMicrogame()
    {
        Debug.Log("Jogo Acabou");
    }

    private void LateUpdate()
    {
        // Logica do seu jogo
    }
}
