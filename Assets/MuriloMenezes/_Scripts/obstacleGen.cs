using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleGen : MonoBehaviour
{

	public GameObject Obstacle;
	public float MinSpeed;
	public float MaxSpeed;
	public float CurrentSpeed;
    public float mult;
    // Start is called before the first frame update
    void Start()
    {

    	CurrentSpeed = MinSpeed;
    	generateObstacle();
        
    }


    public void generateObstacle()
    {
    	GameObject ObstacleInstance = Instantiate(Obstacle, transform.position, transform.rotation);

        ObstacleInstance.GetComponent<ObstacleMov>().obstacleGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {

        if(CurrentSpeed < MaxSpeed)
        {
            CurrentSpeed += mult;
        }
        
    }
}
