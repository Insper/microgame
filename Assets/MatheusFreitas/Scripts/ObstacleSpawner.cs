using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MicrogameInternal;

namespace MatheusFreitas {
    public class ObstacleSpawner : MonoBehaviour
    {
        MicrogameInternal.GameManager gm;
        private float[] _progression = {1.45f, 1.45f, 1.45f, 0.75f, 0.75f, 0.75f};
        public GameObject obstacle;

        // Start is called before the first frame update
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            StartCoroutine(WaitToInstantiate());
        }

        // Update is called once per frame
        void Update()
        {   

        }

        IEnumerator WaitToInstantiate() {
            yield return new WaitForSeconds(_progression[gm.ActiveLevel]);
            var position = new Vector3(Random.Range(-7.5f, 7.5f), -5, 0);
            Instantiate(obstacle, position, Quaternion.identity);    
            StartCoroutine(WaitToInstantiate());
        }
    }
}