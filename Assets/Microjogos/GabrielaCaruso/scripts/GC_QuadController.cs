using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_QuadController : MonoBehaviour
{
    private float offset;
    public GameObject fundo1;
    public GameObject fundo2;
    public GC_ControllerGabrielaCaruso controller;

    void Update()
    {
        if (controller.GetGameData() == true) {
            fundo1.SetActive(true);
            fundo2.SetActive(false);
        }
        if (controller.GetGameData() == false) {
            fundo1.SetActive(false);
            fundo2.SetActive(true);
        }
    }
}
