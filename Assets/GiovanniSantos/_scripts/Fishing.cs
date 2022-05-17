using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// codigo baseado no tutorial do BMo
// https://www.youtube.com/watch?v=YZj-vYL-y6k
// inspirado do jogo de pesca de Stardew Valley

public class Fishing : MonoBehaviour
{

    public Transform panel;
    public Transform top;
    public Transform bottom;

    public Transform magikarp;
    public float motion = 3f;
    public float magikarpRand = 3f;

    float magikarpPos;
    float magikarpSpeed = 1f;
    float magikarpTimer;
    float magikarpTargetPos;


    public Transform hook;
    public float hookSize = .15f;
    public float hookSpeed = .1f;
    public float hookGravity = .05f;
    float hookPos;
    float hookPullVel;

    public Transform progressBarContainer;
    public float hookPower = .3f;
    public float progressBarDecay = .1f;
    float catchProgress;

    bool running = true;
    void FixedUpdate()
    {
        if (running)
        {
            MoveFish();
            MoveHook();   
            CheckProgress();
        }
    }

    private void MoveFish()
    {
        magikarpTimer -= Time.deltaTime;
        if (magikarpTimer <= 0)
        {
            magikarpTimer = Random.value * magikarpRand;
            magikarpTargetPos = Random.value;
        }

        magikarpPos = Mathf.SmoothDamp(magikarpPos, magikarpTargetPos, ref magikarpSpeed, motion);
        magikarp.position = Vector2.Lerp(bottom.position, top.position, magikarpPos);
    }

    private void MoveHook()
    {
        if (Input.GetKey("space"))
        {
            Debug.Log("ESPACO");
            hookPullVel += hookSpeed * Time.deltaTime;
        }
        Debug.Log(hookPos - (hookSize/2));
        if ((hookPos - (hookSize/2) <= 0 && hookPullVel <0) || (hookPos + (hookSize/2) >= 1 && hookPullVel > 0))
        {
            hookPullVel = 0;
        }

        hookPullVel -= hookGravity * Time.deltaTime;
        hookPos = Mathf.Clamp(hookPos + hookPullVel, hookSize/2, 1-(hookSize/2));
        hook.position = Vector2.Lerp(bottom.position, top.position, hookPos);
    }

    private void CheckProgress()
    {
        Vector2 progressBarScale = progressBarContainer.localScale;
        progressBarScale.y = catchProgress;
        progressBarContainer.localScale = progressBarScale;

        float min = hookPos - (hookSize/2);
        float max = hookPos + (hookSize/2);

        if (min < magikarpPos && max > magikarpPos)
        {
            catchProgress += hookPower * Time.deltaTime;
            if (catchProgress >= 1)
            {
                running = false;
                panel.gameObject.SetActive(true);
                Debug.Log("You Win!");
            }
        }
        else
        {
            catchProgress -= progressBarDecay * Time.deltaTime;
        }

        catchProgress = Mathf.Clamp(catchProgress, 0, 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        hook.position = new Vector2(0,0);
        magikarp.position = new Vector2(0,0);
        catchProgress = 0.1f;
    }

}
