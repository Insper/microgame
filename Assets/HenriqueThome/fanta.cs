using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HenriqueThome {
    //gm = MicrogameInternal.GameManager.GetInstance();
    public class fanta : MonoBehaviour {
        private void OnMouseOver() {
            if(Input.GetMouseButton(0)) MicrogameInternal.GameManager.GetInstance().GameLost();
        }
    }
}