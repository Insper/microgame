using UnityEngine;

public class DragonEnemyBehaviour_Pell : MonoBehaviour
{
    private float Timer;
    private Camera cam;
    private float minH, maxH;
    public GameObject fireball;
    public PellizzonController controller;

    private float interval; // dificuldade 1: 1.0f; dificuldade 2: 0.5f; dificuldade 3: 0.25f; 
    void Start()
    {
        Timer = Time.time;
        //https://answers.unity.com/questions/230190/how-to-get-the-width-and-height-of-a-orthographic.html
        cam = Camera.main;
        float heightCamera = 2f * cam.orthographicSize;

        minH = cam.transform.position.y - heightCamera / 2;
        maxH = cam.transform.position.y + heightCamera / 2;
        Timer = Time.time + .5f;

        if (GameData.level >= 10)
        {
            interval = 0.25f;
        }
        else if (GameData.level < 5)
        {
            interval = 1.0f;

        }
        else
        {
            interval = 0.5f;
        }
    }

    public AudioClip fireballSFX;
    void Update()
    {
        if (!controller.startGame) return;
        if (GameData.lost) return;

        float boundY = fireball.GetComponent<CircleCollider2D>().radius;
        if (Timer < Time.time)
        {
            GameObject enemy = GameObject.FindWithTag("Enemy");
            Vector3 enemyPos = enemy.transform.position;
            enemyPos.y = Random.Range(minH + boundY, maxH - boundY);
            Quaternion rotation = enemy.transform.rotation;
            Vector3 spawnPos = enemyPos;
            Instantiate(fireball, spawnPos, rotation);
            AudioManager_Pell.PlaySFX(fireballSFX);
            Timer = Time.time + interval;
        }

    }
}
