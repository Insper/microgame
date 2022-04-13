using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text number;

    void Start()
    {
        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        float timer = Random.Range(0.5f, 2.0f);
        yield return new WaitForSeconds(timer);
        if (GameManager.Instance.Failed == false)
        {
            number.text = "2!";
        }
        timer = Random.Range(0.5f, 2.0f);
        yield return new WaitForSeconds(timer);
        if (GameManager.Instance.Failed == false)
        {
            number.text = "1!";
        }
        timer = Random.Range(0.5f, 2.0f);
        yield return new WaitForSeconds(timer);
        if (GameManager.Instance.Failed == false)
        {   
            number.text = "GO!";
            GameManager.Instance.ChangeState(GameState.Shoot);
        }
    }
}
