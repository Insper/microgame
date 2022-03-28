using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emil {
    public class DotBehaviour : MonoBehaviour
    {
        private void OnMouseOver() {
            if (Input.GetMouseButton(0)) Destroy(gameObject);
        }
    }
}
