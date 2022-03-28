using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emil {
    public class BadDotBehaviour : MonoBehaviour {
        private void OnMouseOver() {
            if(Input.GetMouseButton(0)) MicrogameInternal.GameManager.GetInstance().GameLost();
        }
    }
}