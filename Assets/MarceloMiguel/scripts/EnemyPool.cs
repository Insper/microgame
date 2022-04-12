using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;

    public List<Vector3> listOfPosition;
    // Start is called before the first frame update

    // private static Random rng = new Random();  

    

    void Start()
    {
        listOfPosition = new List<Vector3>{
            new Vector3(0,0.6f,0),new Vector3(5.25f,2.77f,0), 
            new Vector3(5.49f,-0.13f,0),new Vector3(3.07f,-0.13f,0)
        };
        Construir();
    // var shuffledcards = listOfPosition.OrderBy(a => rng.Next()).ToList();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void Construir()
    {
        
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        for(int i = 0; i < listOfPosition.Count; i++)
        {
            
            var enemy =  (GameObject)Instantiate(enemyPrefab, listOfPosition[i], Quaternion.identity, transform);

            
        }
    }


    
}
