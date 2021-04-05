using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGustavoMolina : BaseMGController
{
    private int setJump,setWin;

    public GameObject skateBoy;

    Animator animator;


    protected override void StartMicrogame()
    {
        GameManager.Text.text = "Faça o skatista pular";
        setJump = 0;

        animator = skateBoy.GetComponent<Animator>();
    }

    protected override void Microgame()
    {
        setJump = 1;
        
    }

    protected override void EndMicrogame()
    {
        if (GameData.lost)
        {
            GameManager.Text.text = "Você Perdeu";
        }
        else
        {
            GameManager.Text.text = "Você Ganhou";
        }
    }

    private void LateUpdate()
    {
        if (setJump == 1 && Input.GetKey(KeyCode.Space))
        {
            animator.SetFloat("Velocity", 1.0f);
            setWin = 1;
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }

        if (setWin != 1)
        {
            GameData.lost = true;
        }
        else
        {
            GameData.lost = false;
        }
    }
}
