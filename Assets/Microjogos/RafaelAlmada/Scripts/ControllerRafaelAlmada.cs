using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerRafaelAlmada : BaseMGController {
    public GameObject[] pecas;
    public GameObject[] pecas_nao_jogaveis;

    private Vector3 objectivePos;
    private int randomRot;

    protected override void StartMicrogame() {
        GameManager.Text.text = "Encaixe a peça!";
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
        objectivePos = new Vector3(5f*randomX, -3f, transform.position.z);
        if (piece.tag == "Square") {
            randomRot = 0;
        } else {
            randomRot = Random.Range(0, 3);
        }
        Instantiate(piece, objectivePos, Quaternion.Euler(0f, 0f, 90f*randomRot));
    }

    protected override void EndMicrogame() {
        float playerX = GameObject.FindWithTag("Player").transform.position.x;
        float playerY = GameObject.FindWithTag("Player").transform.position.y;
        GameData.lost = true;
        Debug.Log($"Rot Player Z: {GameObject.FindWithTag("Player").transform.rotation.eulerAngles.z}");
        Debug.Log($"Rot Z aue deveria ser: {90f*randomRot}");
        Debug.Log($"Dist X: {Mathf.Abs(playerX - objectivePos.x)}");
        Debug.Log($"Dist Y: {Mathf.Abs(playerY - objectivePos.y)}");
        if (Mathf.Abs(playerX - objectivePos.x) < 0.5f && Mathf.Abs(playerY - objectivePos.y) < 0.5f) {
            if (GameObject.FindWithTag("Player").transform.rotation.eulerAngles.z == 90f*randomRot || 
                GameObject.FindWithTag("Player").transform.rotation.eulerAngles.z == 90f*(randomRot/2)) {
                GameData.lost = false;
            }
        } 
        // Mensagens de vítoria ou derrota
        if(GameData.lost) {
            GameManager.Text.text = "Você perdeu!";
        } else {
            GameManager.Text.text = "Você ganhou!";
        }   
    }
}
