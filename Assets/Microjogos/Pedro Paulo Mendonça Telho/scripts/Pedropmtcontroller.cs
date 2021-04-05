using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pedropmtcontroller : BaseMGController
{

    public GameObject ironman;
    public GameObject asteroid;
    public AudioClip hit;

    protected override void EndMicrogame()
    {
        if (GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
    }


    protected override void StartMicrogame()
    {
        GameManager.Text.text = "Desvie dos asteroides!";
        if (GameData.level >= 6)
        {
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
        }
        else if (GameData.level >= 3)
        {
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
        }
        else
        {
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f), 6.0f, 0.0f), Quaternion.identity);
        }
        
        asteroid.SetActive(false);

    }

    protected override void Microgame()
    {
        asteroid.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            AudioManager.PlaySFX(hit);
            GameData.lost = true;
            EndMicrogame();
        }
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        if (((ironman.transform.position.x >= 9.0f) && (inputX > 0)) || ((ironman.transform.position.x <= -9.0f) && (inputX < 0))) { 
            ironman.transform.position = new Vector3(ironman.transform.position.x, -4, 0);
        }
        else
        {
            ironman.transform.position += new Vector3(inputX, 0, 0);
        }

        if (asteroid.transform.position.y < ironman.transform.position.y)
        {
            GameData.lost = false;
            EndMicrogame();
        }

    }
}
