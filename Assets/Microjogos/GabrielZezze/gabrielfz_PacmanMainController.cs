using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gabrielfz_PacmanMainController : BaseMGController {
    public bool has_started = false;

    protected override void StartMicrogame() {
        GameManager.Text.text = "Colete todas as moedas!";
        GameData.lost = true;
    }

    protected override void Microgame() {
        has_started = true;
    }

    protected override void EndMicrogame() {
        has_started = false;

        if(GameData.lost) {
            GameManager.Text.text = "Você perdeu!";
        } else {
            GameManager.Text.text = "Você ganhou!";
        }
        
    }

    private void LateUpdate() {

    }
}
