using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchController : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private LogController log;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (log.machadado) return;

        if (col.CompareTag("Player")) timer.Lose();

    }
}