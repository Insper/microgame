using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ME_SnakeController : BaseMGController
{
    [Range(1, 10)]
    public float velocidade;
    private Vector3 direcao;
    private int current= 1;
    float dir=  0.5f;
    int n = 1;
    public float time = 1.0f;
    private int level_dif=0;
    private int ap_count=0;
    private TrailRenderer tr;

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
        // Mensagem inicial
        GameManager.Text.text = "Capture as maçãs e não bata n aparede";

         // place = 0;
        GameData.lost = true;
        tr = GetComponent<TrailRenderer>();
        tr.material = new Material(Shader.Find("Sprites/Default"));
        
        
        if(GameData.level > 10)
        {
            level_dif++;
            velocidade += 1.0f;
        }
        else if(GameData.level > 5)
        {
            velocidade += 1.0f;
            level_dif++;
        }
    
    }
    
    protected override void Microgame()
     {
        Debug.Log("Não Implementada");
        // GameManager.Text.text = GameData.GetTime().ToString();
    }
    

    // Update is called once per frame
    void Update()
    {
    

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        
        if (xInput >0 )
        {  
            current = 1; 
            n=1;
        }
        else if (xInput <0 )
        {  
            current = 1; 
            n= 0;
        }
        else if (yInput >0)
        {
            current =0;
            n=1;
        }
        else if (yInput <0)
        {
            current =0;
            n=0;
        }
        else

        if (current == 1){
            if (n == 1){
                transform.position += new Vector3(dir,0, 0)* Time.deltaTime * velocidade;
            }
            else{
                transform.position += new Vector3(-dir,0, 0)* Time.deltaTime * velocidade;
            }
            
        }
        else{
            if (n == 1){
                transform.position += new Vector3(0,dir, 0)* Time.deltaTime * velocidade;
            }
            else{
                transform.position += new Vector3(0,-dir, 0)* Time.deltaTime * velocidade;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tr.time = time;
        tr.transform.position +=new Vector3(0.1f,0.1f, 0);
        ap_count++;
        
        if(level_dif==0 && ap_count==2){

            GameData.lost = false;
            level_dif++;
            
        }
        else if(level_dif>=1 && ap_count==3){
            
             level_dif++;
             GameData.lost = false;
             

        }
        else if(level_dif>2 && ap_count==4){

            GameData.lost = false;
            level_dif++;
        }
    }
        
}
