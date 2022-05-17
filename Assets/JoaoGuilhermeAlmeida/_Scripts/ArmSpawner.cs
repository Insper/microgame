using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JoaoGuilhermeAlmeida
{
    public class ArmSpawner : MonoBehaviour
    {
        public GameObject mao;

        private int _level;
        private MicrogameInternal.GameManager gm;

        public int amount_saved;

        public bool win;

        // Start is called before the first frame update
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;

            // _level = 2;
            amount_saved = 0;


            if (_level == 0)
            {
                Vector3 posicao = new Vector3(Random.Range(-7f, 7f), -0.94f);
                Instantiate(mao, posicao, Quaternion.identity, transform);
            }
            if (_level == 1)
            {
                Vector3 posicao = new Vector3(Random.Range(-7f, 7f), -0.94f);
                Instantiate(mao, posicao, Quaternion.identity, transform);
                posicao = new Vector3(Random.Range(-7f, 7f), -0.94f);
                Instantiate(mao, posicao, Quaternion.identity, transform);
                posicao = new Vector3(Random.Range(-7f, 7f), -0.94f);
                Instantiate(mao, posicao, Quaternion.identity, transform);
            }
            if (_level >= 2)
            {
                Vector3 posicao = new Vector3(Random.Range(5f, 7f), -0.94f);
                Instantiate(mao, posicao, Quaternion.identity, transform);
                posicao = new Vector3(Random.Range(3f, 5f), -0.94f);
                Instantiate(mao, posicao, Quaternion.identity, transform);
                posicao = new Vector3(Random.Range(0, 2f), -0.94f);
                Instantiate(mao, posicao, Quaternion.identity, transform);
                StartCoroutine(Wait(2));
                StartCoroutine(Wait(4));
                StartCoroutine(Wait(4));
                StartCoroutine(Wait(6));
                StartCoroutine(Wait(8));
            }
        }

        // Update is called once per frame
        void Update()
        {

            if (_level == 0)
            {
                if (amount_saved == 1)
                {
                    print("win");
                    win = true;
                }
            }
            if (_level == 1)
            {
                if (amount_saved == 3)
                {
                    win = true;
                }
            }
            if (_level == 2)
            {
                if (amount_saved == 8)
                {
                    win = true;
                }
            }

        }

        IEnumerator Wait(int n)
        {

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(n);

            Vector3 posicao = new Vector3(Random.Range(-7f, 7f), -0.94f);
            Instantiate(mao, posicao, Quaternion.identity, transform);



        }
    }
}
