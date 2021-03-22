using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaRunController : BaseMGController
{
    public bool flyingObjects;
    public GameObject ninja;
    public GameObject fireball;
    public GameObject obstacle;
    public GameObject spawnPoint;
    public int counter = 0;
    public bool win;


    protected override void StartMicrogame()
    {
        // Mensagem inicial
        GameManager.Text.color = Color.black;
        GameManager.Text.text = "Space = Jump \n\n Arrow Down = Slide";

        if (GameData.level > 4)
        {
            flyingObjects = true;
        }
        else if (GameData.level > 2)
        {
            flyingObjects = true;
        }
        else
        {
            flyingObjects = false;
        }
        // O ninja é desativado enquanto partida não começa
        ninja.SetActive(false);
    }

    protected override void Microgame()
    {
        Debug.Log("Jogo Principal");
        ninja.SetActive(true);
        Invoke("Spawn", 0f);
    }

    protected override void EndMicrogame()
    {
        if (win)
        {
            GameData.lost = false;
            GameManager.Text.text = "Você ganhou!";
        }
        else
        {
            GameData.lost = true;
            GameManager.Text.text = "Você perdeu!";
        }
        GameManager.Text.color = Color.white;
    }

    private void LateUpdate()
    {
        if (ninja.activeInHierarchy)
        {
            win = true;
        }
        else
        {
            win = false;
        }
    }

    void Spawn()
    {
        Vector3 spawnPos = spawnPoint.transform.position;

        counter++;

        float timer;
        int limit;

        if (GameData.level > 4)
        {
            timer = 1.2f;
            limit = 4;
        }
        if (GameData.level > 2)
        {
            timer = 1.4f;
            limit = 4;
        }
        else
        {
            timer = 2.2f;
            limit = 3;
        }

        if (Random.Range(0.0f, 1.0f) > 0.5f && flyingObjects && counter < limit)
        {
            if (Random.Range(0.0f, 1.0f) > 0.5f)
            {
                spawnPos.y = -1.5f;
            }
            Instantiate(fireball, spawnPos, Quaternion.identity);
        }
        else if (counter < limit)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
        Invoke("Spawn", timer);
    }
}
