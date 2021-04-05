// Adaptado do canal do Youtube "Nade"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platform;
    public GameObject platform_power;
    private GameObject currentPlatform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.StartsWith("Platform"))
        {
            if(Random.Range(1,7) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(platform_power, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (4+ Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }else
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (4+ Random.Range(0.2f, 1.0f)));
            }
        }
        else if(collision.gameObject.name.StartsWith("Spring"))
        {
            if(Random.Range(1,7) == 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (4+ Random.Range(0.2f, 1.0f)));
            }else
            {
                Destroy(collision.gameObject);
                Instantiate(platform, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (4+ Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }
        }
    }
}
