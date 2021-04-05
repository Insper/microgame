using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLeonardoMendes : BaseMGController
{

    Vector3 enemy_direction;
    public GameObject skeleton;

    public Vector2[] spawnPosition;
    List<GameObject> enemies;
    
    
    protected override void StartMicrogame()
    {

        GameManager.Text.text = "Fuja dos inimigos!";
        if (GameData.level > 6) enemies = spawnEnemies(4);
        else if (GameData.level > 4) enemies =spawnEnemies(3);
        else enemies = spawnEnemies(2);
    }

    protected override void Microgame()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<SkeletonControllerLeonardoMendes>().isActive = true;
            
        }    }

    protected override void EndMicrogame()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<SkeletonControllerLeonardoMendes>().isActive = false;
            
        }
        if(GameData.lost)
            GameManager.Text.text = "You lost!";
        
        else
            GameManager.Text.text = "You win!";
    }


    List<GameObject> spawnEnemies(int count)
    {
        List<GameObject> enemies = new List<GameObject>();
        for (int i =0;i<count;i++){
            enemies.Add(Instantiate(skeleton, spawnPosition[i], Quaternion.identity));
            }
        return enemies;
    }
}