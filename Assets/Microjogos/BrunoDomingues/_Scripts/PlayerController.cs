using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : BaseMGController
{
    public GameObject plate;
    public GameObject bun1, burger, cheese, bun2;
    public GameObject compare;
    public List<GameObject> ingredients = new List<GameObject>();
    public float timer, delay, plateOffset;

    public float plateSpeed = 10;
    int inputX;
    bool canMove, perfect;

    void Start()
    {
        perfect = true;

        compare = bun1;

        timer = 0f;
        delay = 1.2f;

        ingredients.Add(bun1);
        ingredients.Add(burger);
        ingredients.Add(cheese);
        ingredients.Add(bun2);
    }

    protected override void EndMicrogame()
    {
        if (GameData.lost) GameManager.Text.text = "You failed!";
        else
        {
            foreach (GameObject go in ingredients)
            {
                if (go == bun1) continue;
                else
                {
                    if (Mathf.Abs(go.transform.position.x - compare.transform.position.x) > 0.5f)
                    {
                        Debug.Log("The difference between " + compare.name + " and " + go.name + " is " + Mathf.Abs(go.transform.position.x - compare.transform.position.x));
                        perfect = false;
                        break;
                    }
                    else compare = go;
                }
            }
            if (perfect) GameManager.Text.text = "Perfect!";
            else GameManager.Text.text = "You did it!";
        }
    }

    protected override void StartMicrogame()
    {
        GameManager.Text.text = "Stack the burger!";
        canMove = true;

        if (GameData.level > 4) plateOffset = 2.5f;
        else if (GameData.level > 2) plateOffset = 1.75f;
        else plateOffset = 1.0f;

        bun1.SetActive(false);
        burger.SetActive(false);
        cheese.SetActive(false);
        bun2.SetActive(false);
    }

    protected override void Microgame()
    {
        float posX = Random.Range(plate.transform.position.x - plateOffset, plate.transform.position.x + plateOffset);
        float posY = Random.Range(2.0f, 3.0f);
        bun1.transform.position += new Vector3(posX, posY, 0);

        // Debug.Log("Dropping bun1");

        bun1.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bun1")
        {
            // Debug.Log("bun1 collected");
            col.gameObject.transform.parent = plate.transform;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputX = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            inputX = 1;
        }
        else
        {
            inputX = 0;
        }

        if (canMove) transform.Translate(new Vector3(inputX, 0, 0) * Time.deltaTime * plateSpeed);

        timer += Time.deltaTime;

        if (timer > delay)
        {
            if (!burger.activeSelf)
            {
                // Debug.Log("Dropping burger");
                float posX = Random.Range(plate.transform.position.x - plateOffset, plate.transform.position.x + plateOffset);
                float posY = Random.Range(3.0f, 4.0f);
                burger.transform.position += new Vector3(posX, posY, 0);

                timer = 0f;
                burger.SetActive(true);
            }

            else if (burger.activeSelf && !cheese.activeSelf)
            {
                // Debug.Log("Dropping cheese");
                float posX = Random.Range(plate.transform.position.x - plateOffset, plate.transform.position.x + plateOffset);
                float posY = Random.Range(4.0f, 5.0f);
                cheese.transform.position += new Vector3(posX, posY, 0);

                timer = 0f;
                cheese.SetActive(true);
            }

            else if (cheese.activeSelf && !bun2.activeSelf)
            {
                // Debug.Log("Dropping bun2");
                float posX = Random.Range(plate.transform.position.x - plateOffset, plate.transform.position.x + plateOffset);
                float posY = Random.Range(5.0f, 6.0f);
                bun2.transform.position += new Vector3(posX, posY, 0);

                timer = 0f;
                bun2.SetActive(true);
            }
        }

        foreach (GameObject go in ingredients)
        {
            if ((go.transform.position.y < plate.transform.position.y - 0.5f) && go.activeSelf)
            {
                Debug.Log(go.name + " fell out...");
                GameData.lost = true;
            }
        }
    }
}
