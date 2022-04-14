using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
namespace MarceloMiguel{
    
    public class EnemyPool : MonoBehaviour
    {
        public GameObject enemyPrefab;

        public List<Vector3> listOfPosition;
        // Start is called before the first frame update

        // private static Random rng = new Random();  

        

        void Start()
        {
            listOfPosition = new List<Vector3>{
                new Vector3(0,0.6f,0), new Vector3(4.6f,2.77f,0), 
                new Vector3(5.49f,-0.13f,0), new Vector3(3.07f,-0.13f,0),
                new Vector3(3.05f,-2.39f,0), new Vector3(-1.69f,-4.03f,0) 
            };
            listOfPosition = shuffle(listOfPosition);
            // Construir();
            
            // Debug.Log(listOfPosition);
        // var shuffledcards = listOfPosition.OrderBy(a => rng.Next()).ToList();

        }

        private List<Vector3> shuffle(List<Vector3> list)  
        {  
            
            for(int index = list.Count-1; index>0;index-- ){
                int other = Random.Range(0,index);
                if (other == index){
                    continue;
                }
                Vector3 temp = list[index];
                list[index] = list[other];
                list[other] = temp;
            }
            return list;
        }
        //     for (index in range(len(container) - 1, 0, -1)):
        //             other = random.randint(0, index)
        //             if other == index:
        //                 continue
        //             container[index], container[other] = container[other], container[index]

        // }


        // Update is called once per frame
        void Update()
        {
            
            
        }

        public void Construir(int level)
        {
            
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            for(int i = 0; i < level+1; i++)
            {
                
                var enemy =  (GameObject)Instantiate(enemyPrefab, listOfPosition[i], Quaternion.identity, transform);

                
            }
        }
    }

}