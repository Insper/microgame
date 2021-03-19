using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ThiagovcsController : BaseMGController
{
    float introTime = 0.75f;
    public Slider slider;
    public GameObject panel;
    private float startTime;
    private int i = 0;
    private bool switchSlider;
    public Color Low;
    public Color High;
    public Animator anim;
    private float barSpeed;
    private float barPrecision;

    protected override void EndMicrogame()
    {
        // Mensagens de vítoria ou derrota
        if(GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
        
    }

    protected override void StartMicrogame()
    {
        GameManager.Text.text = "Quebre a madeira!";
        
        if(GameData.level > 4)
        {
           barSpeed = 0.015f;
           barPrecision = 0.90f;
        }
        else if(GameData.level > 2)
        {
            barSpeed = 0.01f;
            barPrecision = 0.90f;
        }
        else 
        {
            barSpeed = 0.005f;
            barPrecision = 0.90f;
        }

        slider.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);

    }

    protected override void Microgame()
    {
        slider.maxValue = 1;
        slider.minValue = 0;
        switchSlider = false;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue );
        slider.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        startTime = Time.time;
    }
    private void Update()
    {
        if(i <= 0){
            if (Input.GetKeyDown("space"))
            {
                if(slider.value >= barPrecision*slider.maxValue){
                    anim.SetTrigger("Win");
                    GameData.lost = false;
                    i = 1;
                }
                else{
                    GameData.lost = true;
                    anim.SetTrigger("Lose");
                    i = 1;
                }
                
            }

            if(slider.value < slider.maxValue && switchSlider != true){
                slider.value += barSpeed;
                slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue );  
                if(slider.value >= slider.maxValue){
                    switchSlider = true;
                }
            }
            else{
                slider.value -= barSpeed;
                slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue ); 
                if(slider.value <= slider.minValue){
                    switchSlider = false;
                }
            }
            if(Time.time - startTime > 4.9 && i <= 0){
                GameData.lost = true;
            }

        }

    }

}
