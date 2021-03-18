using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnDelay = .7f;

    public GameObject car;
    float nextTimeToSpawn = 0f;

    public Transform[] spawnPoints;

    void Update()
    {


        if (nextTimeToSpawn <= Time.time)
        {
            SpawnCar();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }
    void SpawnCar()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }
}
