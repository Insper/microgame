using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Text txt;

    public int won;

    void Update()
    {
        if (won == 1)
        {
            txt.text = "You WON!!!";
            gameOverMenu.SetActive(true);
        }
        else if (won == 2)
        {
            txt.text = $"Lost, try agin??";
            gameOverMenu.SetActive(true);
        }
    }

    public void NewGame()
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene("Lumberjack");
    }
}
