using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasArrow : MonoBehaviour {
    [SerializeField]
    private GameObject green;

    [SerializeField]
    private GameObject black;

    [SerializeField]
    private GameObject red;

    public int key;

    public Vector3 center() {
        return green.GetComponent<SpriteRenderer>().bounds.center;
    }

    public bool press(int k) {
        black.SetActive(false);

        if (key == k) {
            red.SetActive(false);
            green.SetActive(true);
            return true;
        }
        green.SetActive(false);
        red.SetActive(true);
        return false;
    }
}
