using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class l_CarPool : MonoBehaviour
{
    public GameObject car;
    public List<GameObject> carList;
    public int n;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < n; i++){
            GameObject obj = Instantiate(car);
            carList.Add(obj);
            obj.SetActive(false);
        }
        InvokeRepeating(nameof(spawnCar),2,1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCar()
    {
        int random = Random.Range(-1,2) * 2;
        Vector3 newPos = transform.position;
        newPos.x = random;
        transform.position = newPos;

        for(int i = 0; i < carList.Count; i++){
    
            if(!carList[i].activeInHierarchy){
                carList[i].transform.position = transform.position;
                carList[i].transform.rotation = transform.rotation;
                carList[i].SetActive(true);
                return;

            }
      
        }
    }


}
