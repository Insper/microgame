using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AndreRocco
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject Gun;
        void Update()
        {
            if (GameManager.Instance.GameState == GameState.Countdown)
            {
                if (Input.GetButton("Jump"))
                {
                    Gun.SetActive(true);
                    GameManager.Instance.ChangeState(GameState.Fail);
                }
            }

            if (GameManager.Instance.GameState == GameState.Shoot)
            {
                if (Input.GetButton("Jump"))
                {
                    Gun.SetActive(true);
                    GameManager.Instance.ChangeState(GameState.Win);
                }
            }
        }
    }
}
