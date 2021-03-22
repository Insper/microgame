using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllerGuilherme : BaseMGController {

    // Objetos a serem gerenciados
    public GameObject camaleao;
    public GameObject camera;
    public int corIdx = 0;

    public List<Color> bgColors = new List<Color>();

    // Exemplo de finalização de jogo
    protected override void EndMicrogame() {
        Color camaleaoColor = camaleao.GetComponent<SpriteRenderer>().color;
        Color bgColor = camera.GetComponent<Camera>().backgroundColor;

        // Mensagens de vítoria ou derrota
        if (bgColor != camaleaoColor) {
            GameManager.Text.text = "Você perdeu!";
        }
        else {
            GameManager.Text.text = "Você ganhou!";
        }

    }

    // Exemplo de inicialização de jogo
    protected override void StartMicrogame() {
        // camaleao.GetComponent<SpriteRenderer>().color = new Color(0,0,0);
        // camaleao.GetComponent<SpriteRenderer>().color = new Color32(255 , 255 , 255, 1);

        // Mensagem inicial
        GameManager.Text.text = "Camufle o camaleão! (Espaço)";
        if (GameData.level >= 0) {
            bgColors.Add(new Color32(200 , 247 , 52, 255));
            bgColors.Add(new Color32(212 , 137 , 44 , 255));
            bgColors.Add(new Color32(235 , 61 , 168 , 255));
            bgColors.Add(new Color32(44 , 71 , 212 , 255));
            bgColors.Add(new Color32(21 , 245 , 128 , 255));
        }
        if (GameData.level > 4) {
            bgColors.Add(new Color32(158 , 104 , 96 , 255));
            bgColors.Add(new Color32(224 , 235 , 190 , 255));

        }
        if (GameData.level > 8) {
            bgColors.Add(new Color32(143 , 180 , 235 , 255));
            bgColors.Add(new Color32(104 , 126 , 158 , 255));
        }
        camera.GetComponent<Camera>().backgroundColor = bgColors[bgColors.Count-1];
    }

    // Exemplo de jogo principal
    protected override void Microgame() {

    }

    // Método chamado continuamente a cada quadro
    private void Update() {
        if (Input.GetKeyDown("space")) {
            corIdx += 1;
            if (corIdx >= bgColors.Count) {
                corIdx = 1;
            }

            camaleao.GetComponent<SpriteRenderer>().color = bgColors[corIdx];
        }


    }

}
