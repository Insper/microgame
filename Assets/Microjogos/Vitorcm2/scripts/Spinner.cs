using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

	private float dificuldade;
	public bool isStoped = false;
    // public Controller controle;


	void Start ()
	{
		if (GameData.level >= 0){
            dificuldade = 2;
        } else if (GameData.level > 5){
            dificuldade = 2;
        } else {
            dificuldade = 1;
        }
	}
	
	// Update is called once per frameQ
	void FixedUpdate () {
        // if (!controle.rodando) return;
		if (Input.GetKey (KeyCode.Space)) 
		{
			isStoped = true;
		}
        if (!isStoped){
            if (dificuldade == 1)
            {
                transform.Rotate (Vector3.forward,  4);
            } else if (dificuldade == 2)
            {
                transform.Rotate (Vector3.forward,  7);
            } else if (dificuldade == 3)
            {
                transform.Rotate (Vector3.forward, 10);
            } else
            {
                isStoped = true;
            }
        }

	}

}