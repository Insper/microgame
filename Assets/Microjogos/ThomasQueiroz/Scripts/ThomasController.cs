using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasController : BaseMGController {
    private bool ended = false;

    [SerializeField]
    private ThomasSpawner spawner;

    private GameObject[] arrows;
    private int arrows_idx = 0;


    // Pre start
    protected override void StartMicrogame() {
        GameData.lost = true;
        GameManager.Text.text = "Aperte as setas na ordem certa";
    }

    // Start
    protected override void Microgame() {
        arrows = spawner.Spawn(GameData.level);
    }

    // End
    protected override void EndMicrogame() {
        ended = true;
        for (int i = 0; i < arrows.Length; i++) {
            Destroy(arrows[i]);
        }
        // Mensagens de vítoria ou derrota
        if (GameData.lost) {
            GameManager.Text.text = "Você perdeu!";
        } else {
            GameManager.Text.text = "Você ganhou!";
        }

    }


    private void Update() {
        if (ended || arrows == null)
            return;
        // direita 0;
        // cima 1;
        // esquerda 2;
        // baixo 3;

        int key = -1;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            key = 0;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            key = 1;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            key = 2;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            key = 3;
        if (key != -1 && arrows_idx < arrows.Length) {
            if (arrows[arrows_idx].GetComponent<ThomasArrow>().press(key)) {
                arrows_idx++;
                if (arrows_idx == arrows.Length) {
                    GameData.lost = false;
                    ended = true; // Input is no longer relevant
                }
            }
        }
    }

}
