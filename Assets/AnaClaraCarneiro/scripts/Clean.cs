using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AnaClaraCarneiro {
    public class Clean : MonoBehaviour
    {
        
        void OnBecameInvisible() {
            Destroy(gameObject);
        }

    }
}

