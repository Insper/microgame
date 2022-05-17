using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AndreRocco
{
    public class Countdown : MonoBehaviour
    {
        public Text number;
        public Text instr;

        public static float minRandom;
        public static float maxRandom;
        public static float instTime;

        void Start()
        {
            StartCoroutine(Count());
        }

        IEnumerator Count()
        {
            number.text = "";
            yield return new WaitForSeconds(instTime);
            number.text = "3!";
            instr.text = "";
            
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
