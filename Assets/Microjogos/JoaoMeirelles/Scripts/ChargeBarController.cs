using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBarController : MonoBehaviour
{
    public double charge;
    double chargeDelta = 10.0f;
    public GameObject Cannon;
    public GameObject CannonBall;
    float maxCharge = 30.0f;
    bool keyIsDown = false;
    bool launch = false;
    public float angle;
    int numberOfShots = 1;
    int shotsMade = 0;
    GameObject chargeBar;
    void Start()
    {
        chargeBar = GameObject.FindGameObjectsWithTag("ChargeBar")[0];
        charge = 0;
        angle = Random.Range(-20.0f,-75.0f);
        Debug.Log("Rotation " + angle);
        transform.Rotate(0.0f,0.0f,angle);
        Instantiate(Cannon, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }

    void Update()
    {
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
            GameObject instance = Instantiate(CannonBall, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
            CannonBallBehaviour ball = instance.GetComponent<CannonBallBehaviour>();
            if(ball != null)
            {
                ball.cannon = gameObject;
                ball.angle = angle;
            }
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
}
