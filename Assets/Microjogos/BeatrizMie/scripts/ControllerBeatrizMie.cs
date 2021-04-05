using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerBeatrizMie : BaseMGController
{
    // Objetos a serem gerenciados
    public GameObject puffle;
    public GameObject UFO;

    private int n_UFO;

    GameObject InstantiatedAlien;
    Vector3 position;

    // Exemplo de finalização de jogo
    protected override void EndMicrogame()
    {
        // Mensagens de vitoria ou derrota
        if(GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
    }

    // Exemplo de inicialização de jogo
    protected override void StartMicrogame()
    {
        // Mensagem inicial
        GameManager.Text.text = "Fuja dos aliens!";
        
        // Raquete é escalada conforme o nível
        if (GameData.level > 2)
        {
            n_UFO = 3;
        }
        else if (GameData.level > 1)
        {
            n_UFO = 2;
        }
        else 
        {
            n_UFO = 1;
        }

        // Player é desativado enquanto partida não começa
        puffle.SetActive(false);
    }

    void BuildAlienArmy()
    {
        for (int i = 0; i < n_UFO; i++)
        {
            position = new Vector3(-6 + 3f * i, 3);
            InstantiatedAlien = Instantiate(UFO, position, Quaternion.identity, transform);

            position = new Vector3(4 + 3f * i, -3);
            InstantiatedAlien = Instantiate(UFO, position, Quaternion.identity, transform);

            position = new Vector3(4 + 3f * i, 3);
            InstantiatedAlien = Instantiate(UFO, position, Quaternion.identity, transform);

            position = new Vector3(-6 + 3f * i, -3);
            InstantiatedAlien = Instantiate(UFO, position, Quaternion.identity, transform);
        }
    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        puffle.SetActive(true);
        BuildAlienArmy();
    } 
}
