using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rs_Controller : BaseMGController
{
    [SerializeField] private GameObject startMenu;

    public bool end = false;
    public bool start = false;

    private float startTime;

    protected override void StartMicrogame()
    {
        Debug.Log("Inicio do Jogo");
        start = true;
        startTime = Time.time;
    }

    protected override void WinMicrogame()
    {
        Debug.Log("Jogador Ganhou");
    }

    protected override void EndMicrogame()
    {
        Debug.Log("Jogador Perdeu");
    }

    private void LateUpdate()
    {
        if (end || !start) return;

        float timer = (Time.time - startTime);

        if (timer > GameData.GetTime()) Lose();
    }

    public void Lose()
    {
        end = true;
        EndMicrogame();
    }

    public void Win()
    {
        end = true;
        WinMicrogame();
    }
}