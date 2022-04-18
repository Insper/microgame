using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatheusFreitas {
    public class ScrollBackground : MonoBehaviour
    {
        MicrogameInternal.GameManager gm;
        private float[] _progression = {0.5f, 0.75f, 1, 1.25f, 1.5f, 1.75f};
        private Renderer re;

        // Start is called before the first frame update
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            re = GetComponent<Renderer>();    
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 offset = new Vector2(0, -Time.time * _progression[gm.ActiveLevel]);
            re.material.mainTextureOffset = offset;   
        }

    }
}