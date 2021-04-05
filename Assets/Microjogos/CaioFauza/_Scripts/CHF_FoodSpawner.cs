using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHF_FoodSpawner : MonoBehaviour
{
    public GameObject ChickenLeg, Cookie, Eggs, FishSteak, Pickle;
    List<GameObject> fruitList = new List<GameObject>{};
    int fruitCounter = 0;

    void Start()
    {   
        fruitList.AddRange(new GameObject[]{ ChickenLeg, Cookie, Eggs, FishSteak, Pickle });
    }

    void Update()
    {   
        while(fruitCounter < 5){
            Vector3 positionLow = new Vector3(Random.Range(-6.0f, -1.2f), Random.Range(-6.0f, -1.2f));
            Vector3 positionHigh = new Vector3(Random.Range(1.2f, 6.0f), Random.Range(1.2f, 6.0f));
            int selected = Random.Range(0, 5);
            Instantiate(fruitList[selected], positionLow, Quaternion.identity, transform);
            Instantiate(fruitList[selected], positionHigh, Quaternion.identity, transform);
            fruitCounter++;
        }        
    }
}
