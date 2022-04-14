using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AndreRocco
{
    public class Countdown : MonoBehaviour
    {
        public Text number;

        public static float minRandom;
        public static float maxRandom;

        void Start()
        {
            StartCoroutine(Count());
        }

        IEnumerator Count()
        {
            float timer = Random.Range(minRandom, maxRandom);
            yield return new WaitForSeconds(timer);
            if (GameManager.Instance.Failed == false)
            {
                number.text = "2!";
            }
            timer = Random.Range(minRandom, maxRandom);
            yield return new WaitForSeconds(timer);
            if (GameManager.Instance.Failed == false)
            {
                number.text = "1!";
            }
            timer = Random.Range(minRandom, maxRandom);
            yield return new WaitForSeconds(timer);
            if (GameManager.Instance.Failed == false)
            {
                GameManager.Instance.ChangeState(GameState.Shoot);
            }
        }
    }
}
