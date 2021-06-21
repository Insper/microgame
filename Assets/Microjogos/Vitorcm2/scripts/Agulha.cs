using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Agulha : MonoBehaviour {
	public Spinner _spinner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		if (!_spinner.isStoped)
			return;
        if(col.gameObject.CompareTag("Certo"))
        {
                GameData.lost = false;
        } else{
            GameData.lost = true;
        }
		

	}

}