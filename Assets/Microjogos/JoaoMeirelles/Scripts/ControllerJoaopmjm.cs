using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerJoaopmjm : BaseMGController
{
    public GameObject Cannon;
    public GameObject CannonBall;
    public GameObject Target;
    GameObject chargeBar;
    Transform floor;
    double velocity;
    float angleCannon;
    bool landed;
    double charge;
    int numberOfShots = 1;
    int shotsMade = 0;
    double chargeDelta = 10.0f;
    float maxCharge = 30.0f;
    bool keyIsDown = false;
    bool launch = false;
    
    float pos;

    CannonBallBehaviour ball;

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

    protected void SpawnFloor()
    {
        floor = GameObject.FindGameObjectsWithTag("Floor")[0].GetComponent<Transform>();
        floor.localScale = new Vector3(Screen.width, 0.5f, 0.0f);
    }
    protected void SpawnCannon()
    {
        chargeBar = GameObject.FindGameObjectsWithTag("ChargeBar")[0];
        chargeBar.GetComponent<Image>().fillAmount = 0.0f;
        charge = 0;
        angleCannon = Random.Range(-20.0f,-75.0f);
        Cannon = Instantiate(Cannon, new Vector3(-10,-5,0), Quaternion.AngleAxis(angleCannon, Vector3.forward));
    }
    protected void Shoot()
    {
        Vector3 bicoPos = Cannon.transform.position;
        bicoPos = new Vector3(bicoPos.x + Mathf.Abs(Mathf.Cos(angleCannon))*0.5f, bicoPos.y + Mathf.Abs(Mathf.Sin(angleCannon)*0.5f), 0.0f);
        CannonBall = Instantiate(CannonBall, bicoPos, Quaternion.AngleAxis(angleCannon, Vector3.forward));
        CannonBall.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(Mathf.Cos(angleCannon))*(float)charge, Mathf.Abs(Mathf.Sin(angleCannon)*(float)charge));
        CannonBall.GetComponent<Rigidbody2D>().rotation = angleCannon;
    }
    void Destroi(GameObject go)
    {
        Destroy(go);
    }
    protected void spawnTarget(float pos)
    {
        Target = Instantiate(Target, new Vector3(pos,-5f,0.0f),Quaternion.identity) as GameObject;  // instatiate the object
    }
    protected void targetSize(float size)
    {
        Target.transform.localScale = new Vector3(size, 0.5f, 1.0f);
    }

    protected void initScene()
    {
        SpawnFloor();
        SpawnCannon();
        spawnTarget(pos);
    }
    protected override void StartMicrogame()
    {
        // Mensagem inicial
        GameManager.Text.text = "Atinja a plataforma";
        GameData.lost = true;
        
        // Raquete é escalada conforme o nível
        if(GameData.level > 4)
        {
            initScene();
            targetSize(1.0f);
        }
        else if(GameData.level > 2)
        {
            initScene();
            targetSize(2.0f);
        }
        else 
        {
            initScene();
            targetSize(3.0f);
        }
    }

    private void Update()
    {
        if(CannonBall.GetComponent<CannonBallBehaviour>().getLandingStatus()) GameData.lost = false;
        if(shotsMade >= numberOfShots)return;
        if(keyIsDown)
        {
            if(charge < maxCharge)
            {
                charge += chargeDelta * Time.deltaTime;
                if(charge > maxCharge)charge = maxCharge;
                chargeBar.GetComponent<Image>().fillAmount = (float)charge/maxCharge;
            }
        } 
        if(launch)
        {
            if(shotsMade >= numberOfShots)return;
            shotsMade++;
            Shoot();
            launch = false;
        } 
        if(Input.GetKeyDown("space"))
        {
            keyIsDown = true;
        }
        if(Input.GetKeyUp("space"))
        {
            keyIsDown = false;
            launch = true;
            Debug.Log("Space Released with charge of " + charge);
        }
    }
    protected override void Microgame()
    {
        // Alvo é spawnado em posição aleatória
        float pos = Random.Range(-5.0f,8.0f);
    }
}
