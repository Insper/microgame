using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    // Start is called before the first frame update
    public void Iniciar()
    {
        MicrogameInternal.GameManager.GetInstance().NextGame();
    }
}