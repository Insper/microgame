using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerMichel : BaseMGController
{
    public GameObject player;
    public GameObject obstaclePrefab;
    private int numberOfObstacles;
    public float time;
    float[] positions = new float[] { 6.25f, -10.2f};

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
        GameManager.Text.text = "Pule ou abaixe!!";
        
        if(GameData.level > 10)
        {
            numberOfObstacles = 3;
        }
        else if(GameData.level > 5)
        {
            numberOfObstacles = 2;
        }
        else 
        {
            numberOfObstacles = 1;
        }

    }

    protected override void Microgame()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner(){
        for (int i = 0; i < numberOfObstacles; i++)
        {
            float posy = positions[(int)Random.Range(0,2)];
            Instantiate(obstaclePrefab, new Vector3(10f, posy, 0), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    private void Update()
    {
        time+=Time.deltaTime;
        if (!GameData.lost){
            if((Input.GetKeyDown("space")||Input.GetKeyDown("up")) && time>=0.7f){
                player.GetComponent<Animator>().SetTrigger("Jump");
                player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0.0f, 14.0f, 0.0f), ForceMode2D.Impulse);
                time = 0f;
            }
            else if((Input.GetKeyDown("down")) && time>=0.7f){
                player.GetComponent<Animator>().SetTrigger("Down");
                time = 0f;
            }
        }
    }
    
}

