using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rs_BranchController : MonoBehaviour {
    [SerializeField] private rs_Controller controller;
    [SerializeField] private rs_LogController log;

    private void OnTriggerEnter2D(Collider2D col) {
        if (log.machadado)
            return;

        if (col.CompareTag("Player"))
            controller.Lose();

    }
}