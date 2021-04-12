using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBarController : MonoBehaviour
{
    public double charge;
    public float angle;
    public GameObject Cannon;
    public GameObject CannonBall;
    public GameObject Target;

    GameObject chargeBar;
    int numberOfShots = 1;
    int shotsMade = 0;
    double chargeDelta = 10.0f;
    float maxCharge = 30.0f;
    bool keyIsDown = false;
    bool launch = false;
    
    void Start()
    {
        chargeBar = GameObject.FindGameObjectsWithTag("ChargeBar")[0];
        chargeBar.GetComponent<Image>().fillAmount = 0.0f;
        charge = 0;
        angle = Random.Range(-20.0f,-75.0f);
        Debug.Log("Rotation " + angle);
        GameObject newObject = Instantiate(Target, new Vector3(Random.Range(-5.0f,8.0f),-3.75f,0.0f),Quaternion.identity) as GameObject;  // instatiate the object
        newObject.transform.localScale = new Vector3(Random.Range(1.0f,3.0f), 0.5f, 1.0f);
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
