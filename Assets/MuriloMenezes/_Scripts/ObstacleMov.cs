using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMov : MonoBehaviour
{

	public obstacleGen obstacleGenerator;

    // Update is called once per frame
    void Update()
    {

    	transform.Translate(Vector2.left * obstacleGenerator.CurrentSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if(collision.gameObject.CompareTag("next"))
    	{
    		obstacleGenerator.generateObstacle();

    	}

    	if(collision.gameObject.CompareTag("finish"))
    	{
    		Destroy(this.gameObject);
    	}

    }
}
