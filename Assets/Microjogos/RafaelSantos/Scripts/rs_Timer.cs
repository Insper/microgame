using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rs_Timer : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;

    private float timer = 5;

    public bool start = false; 

    void Start()
    {
        GetComponent<Text>().text = "5,000";
    }

    void Update()
    {
        if (!start) return;
        if (timer > 0) timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            Lose();
        }
        else
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Log");
            if (objs.Length == 0) Win();
        }
        GetComponent<Text>().text = $"{timer.ToString("F3")}";
    }

    public void Lose()
    {
        start = false;
    }

    public void Win()
    {
        start = false;
    }

    public void Easy() { SetDificulty("easy");  }
    public void Medium() { SetDificulty("medium"); }
    public void Hard() { SetDificulty("hard"); }

    private void SetDificulty(string d)
    {
        if (d == "easy") timer = 5f;
        if (d == "medium") timer = 4f;
        if (d == "hard") timer = 3f;

        GetComponent<Text>().text = $"{timer.ToString("F3")}";

        startMenu.SetActive(false);
    }
}
