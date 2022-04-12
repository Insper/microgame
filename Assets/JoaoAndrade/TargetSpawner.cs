using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JoaoAndrade {
    public class TargetSpawner : MonoBehaviour
    {
    public GameObject[] targetPrefabs;
    // Start is called before the first frame update
    private Color[] _possibleColors = {Color.blue, Color.red, Color.green, Color.yellow, Color.black, Color.white, Color.magenta};

    void Start()
    {
        Invoke(nameof(Spawn), 1.0f);
        
    }

    // Update is called once per frame
    private void Spawn(){
        for (int j = 0; j <targetPrefabs.Length; j++){
            for (int i = 0; i< _possibleColors.Length; i++){
                float spawnX = Random.Range(-7, 7);
                float spawnY = Random.Range(-4, 2);
                Vector3 spawnPoint = new Vector3(spawnX, spawnY, 0);
                GameObject target = Instantiate(this.targetPrefabs[j], spawnPoint, Quaternion.identity);
                target.GetComponent<Renderer>().material.color = _possibleColors[i];
                
            }
        }
    }
    }
}
