using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rs_Controller : BaseMGController {
    [SerializeField] private GameObject startMenu;

    public bool end = false;
    public bool start = false;

    private float startTime;

    protected override void StartMicrogame() {
        //Debug.Log("Inicio do Jogo");
        GameManager.Text.text = "Cut the tree";
        start = true;
        startTime = Time.time;
    }

    protected override void EndMicrogame() {
        // Mensagens de vítoria ou derrota
        if (GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }

    }

    protected override void Microgame() { }

    private void LateUpdate() {
        if (end || !start)
            return;

        float timer = (Time.time - startTime);

        if (timer > GameData.GetTime())
            Lose();
    }

    public void Lose() {
        end = true;
        GameData.lost = true;
    }

    public void Win() {
        end = true;
        GameData.lost = false;
    }
}