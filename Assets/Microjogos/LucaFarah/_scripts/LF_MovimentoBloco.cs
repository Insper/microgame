using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LF_MovimentoBloco : BaseMGController
{
    public static float altura = 20.0f;
    public static float largura = 42f;
    public static float velocidade = 0.2f;

    private bool goingLeft = true;
    private int jumpNumber = 0;
    private bool destruiu = false;
    public List<GameObject> blockList1;
    public List<GameObject> blockList2;
    public List<GameObject> blockList3;
    public AudioClip glassBreak;


    protected override void EndMicrogame()
    {
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
        //Começa perdendo 
        GameData.lost = true;
        GameManager.Text.text = "Vá até o final sem quebrar o vidro!";
                // Raquete é escalada conforme o nível
        if(GameData.level > 4)
        {
            velocidade = 0.4f;
        }
        else if(GameData.level > 2)
        {
            velocidade = 0.3f;
        }
        else 
        {
            velocidade = 0.2f;
        }
        
    }

    protected override void Microgame()
    {

    }
    // Update is called once per frame
    private void Update()
    {
        if(goingLeft){
            transform.position += new Vector3(-velocidade,0,0);
            if(!ValidMove()){
                transform.position -= new Vector3(-velocidade,0,0); 
                goingLeft = false;
            }
        }
        else{
            transform.position += new Vector3(velocidade,0,0);
            if(!ValidMove()){
                transform.position -= new Vector3(velocidade,0,0);
                goingLeft = true;
             }
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            jumpNumber += 1;
            if(!ValidJump()){
            foreach(Transform child in transform)
            {
                destruiu = true;
                Destroy(child.gameObject);
                LF_AudioManager.PlaySFX(glassBreak);
                GameManager.Text.text = "Você perdeu!";
            }
            }
            else{
                transform.position += new Vector3(0,-6,0); 
            }
        }
        if(jumpNumber == 3 && !destruiu ){
            GameData.lost = false;
            GameManager.Text.text = "Você ganhou!";
        }   
    }

    bool ValidJump(){
        foreach(Transform children in transform){
            float X = children.transform.position.x;
            if(jumpNumber == 1){
                if(X<blockList1[0].transform.position.x || X > blockList1[1].transform.position.x){
                    return false;
                }
            }
            else if(jumpNumber == 2){
                if(X>blockList2[0].transform.position.x && X < blockList2[1].transform.position.x){
                    return true;
                }
                else if(X>blockList2[2].transform.position.x && X < blockList2[3].transform.position.x){
                    return true;
                }
                else{return false;}
            }
            else if(jumpNumber == 3){
                if(X<blockList3[0].transform.position.x || X > blockList3[1].transform.position.x){
                    return false;
                }
            }
        }
        return true;
    }

    bool ValidMove(){
        foreach(Transform children in transform){
            float X = children.transform.position.x;
            float Y = children.transform.position.y;
            if(X < -7f || X >= largura || Y < 0.0f || Y >= altura ){return false;}
        }
        return true;
    }
}
