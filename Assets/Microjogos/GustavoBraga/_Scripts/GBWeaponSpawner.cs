using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBWeaponSpawner : MonoBehaviour
{
    public GameObject dagger;
    public GBPlayerController pC;
    public Transform lB, rB;
    public float spawnRate = 1.0f;
    float timePassed = 0f;

    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= spawnRate && pC.active)
        {
            timePassed = 0f;
            Instantiate(dagger, new Vector3(Random.Range(lB.transform.position.x, rB.transform.position.x), transform.position.y, 0f), Quaternion.Euler(new Vector3(0f, 0f, 130f)), transform);
        }
    }
}
