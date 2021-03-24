using UnityEngine;
using System.Collections;

public class TubeSpawner : MonoBehaviour
{
    public GameObject tube;
    public float height;
    public float maxTimer = 1;
    public float timer = 1;
    // Use this for initialization
    void Start()
    {
        GameObject newTube = Instantiate(tube);
        newTube.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTimer)
        {
            GameObject newTube = Instantiate(tube);
            newTube.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newTube, 20);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
