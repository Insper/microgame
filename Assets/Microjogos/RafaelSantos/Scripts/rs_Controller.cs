using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rs_Controller : BaseMGController
{
    [SerializeField] private GameObject startMenu;

    public bool end = false;

    private float startTime;

    protected override void StartMicrogame()
    {
        Debug.Log("Inicio do Jogo");
    }

    protected override void WinMicrogame()
    {
        Debug.Log("Jogador Ganhou");
        end = true;
    }

    protected override void EndMicrogame()
    {
        Debug.Log("Jogador Perdeu");
        end = true;
    }

    void Start()
    {
        startTime = Time.time;
    }

    private void LateUpdate()
    {
        if (end) return;

        float timer = (Time.time - startTime);

        if (timer > GameData.GetTime()) EndMicrogame();
        else
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Log");
            if (objs.Length == 0)
            {
                WinMicrogame();
            }
        }
    }

    public void Lose()
    {
        EndMicrogame();
    }
}