using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatheusFreitas {
    public class MoveObstacleUp : MonoBehaviour
    {
        MicrogameInternal.GameManager gm;
        private float[] _progression = {5, 6.5f, 8, 10.5f, 11, 11.5f};
        private float _speed;

        // Start is called before the first frame update
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(_progression[gm.ActiveLevel]);
            transform.position += new Vector3(0, _progression[gm.ActiveLevel], 0) * Time.deltaTime; 
        }

        void OnBecameInvisible() {
            Destroy(gameObject);
        }
    }
}