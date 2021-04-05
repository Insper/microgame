using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1f;

    public GameObject hexagonPrefab;

    private float nextimeToSpawn = 0f;

    public WillianrslController controller;


    // Update is called once per frame
    void Update()
    {

        if (!controller.gameIsRunning)
        {
            return;
        } 

        if (Time.time >= nextimeToSpawn)
        {
            Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            nextimeToSpawn = Time.time + 1f / spawnRate;
        }
    }
}
