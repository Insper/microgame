using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThaliaLoiola {
    public class FruitSpawner : MonoBehaviour {
        public GameObject fruitPrefab;
        public Transform[] spawnPoints;
        public float minDelay = 0.1f;
        public float maxDelay = 1f;
        int count = 0;
        public bool acabou = false;

        // Start is called before the first frame update
        void Start() {
            StartCoroutine(SpawnFruits());
        }

        IEnumerator SpawnFruits() {
            while (count < 4) {
                float delay = Random.Range(minDelay, maxDelay);
                yield return new WaitForSeconds(delay);

                int spawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[spawnIndex];

                GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);

                // if (spawnedFruit) {
                //     count++;
                //     Debug.Log(count);
                // }
                // if passar do tamanho da tela -> destroi elas 
                count++;
                Debug.Log(count);
                Destroy(spawnedFruit, 5f);

            }

            if (count == 4) {
                acabou = true;
            }
        }

    }
}
