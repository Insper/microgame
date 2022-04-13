using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmSpawner : MonoBehaviour
{
    public GameObject mao;

    private int _level;
    private MicrogameInternal.GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = MicrogameInternal.GameManager.GetInstance();
        _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;


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
        if (_level == 2)
        {
            Vector3 posicao = new Vector3(Random.Range(-7f, 7f), -0.94f);
            Instantiate(mao, posicao, Quaternion.identity, transform);
            posicao = new Vector3(Random.Range(-7f, 7f), -0.94f);
            Instantiate(mao, posicao, Quaternion.identity, transform);
            posicao = new Vector3(Random.Range(-7f, 7f), -0.94f);
            Instantiate(mao, posicao, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
