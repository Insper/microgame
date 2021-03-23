using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerRafaelAlmada : BaseMGController {
    public GameObject[] pecas;
    public GameObject[] pecas_nao_jogaveis;

    private Vector3 objectivePos;

    protected override void StartMicrogame() {
        GameManager.Text.text = "Encaixe a peça\napertando espaço!";
    }

    protected override void Microgame() {
        int index = Random.Range(0, pecas.Length);
        float randomX = Random.Range(-6.0f, 6.0f);
        Vector3 playerPos = new Vector3(randomX, transform.position.y, transform.position.z);
        CreateObjective(pecas_nao_jogaveis[index]);
        Instantiate(pecas[index], playerPos, Quaternion.identity);
    }

    private void CreateObjective(GameObject piece) {
        float randomX = Random.Range(-1f, 1f);
        objectivePos = new Vector3(5f*randomX, -2.5f, transform.position.z);
        int randomRot = Random.Range(0, 3);
        Instantiate(piece, objectivePos, Quaternion.Euler(0f, 0f, 90f*randomRot));
    }

    protected override void EndMicrogame() {
        float playerX = GameObject.FindWithTag("Player").transform.position.x;
        float playerY = GameObject.FindWithTag("Player").transform.position.y;
        if (Mathf.Abs(playerX - objectivePos.x) >= 0.25f && Mathf.Abs(playerY - objectivePos.y) >= 0.25f) {
            GameData.lost = true;
        } else {
            GameData.lost = false;
        }
        // Mensagens de vítoria ou derrota
        if(GameData.lost) {
            GameManager.Text.text = "Você perdeu!";
        } else {
            GameManager.Text.text = "Você ganhou!";
        }   
    }
}
