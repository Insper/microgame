using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject arrow;
    private GameObject new_arrow(Vector3 pos) {
        GameObject a = Instantiate(arrow, pos, Quaternion.identity, transform);
        Transform at = a.GetComponent<Transform>();
        ThomasArrow ata = a.GetComponent<ThomasArrow>();

        at.localScale = new Vector3(4f, 4f);
        int key = Random.Range(0, 4);

        at.RotateAround(ata.center(), new Vector3(0, 0, 1), key * 90f);
        ata.key = key;
        return a;
        // Debug.Log(i + " " + key);
    }

    public GameObject[] Spawn(int level) {
        if (level < 5) {
            GameObject[] arr = new GameObject[6];
            for (int i = 0; i < 6; i++) {
                Vector3 pos = new Vector3(-7f + 2.5f * i, -2);
                arr[i] = new_arrow(pos);
            }
            return arr;
        } else if (level < 15) {
            GameObject[] arr = new GameObject[9];
            for (int i = 0; i < 3; i++) {
                Vector3 pos = new Vector3(-3.25f + 2.5f * i, 0.5f);
                arr[i] = new_arrow(pos);
                pos.y -= 2.3f;
                arr[i + 3] = new_arrow(pos);
                pos.y -= 2.3f;
                arr[i + 6] = new_arrow(pos);
            }
            return arr;
        } else {
            GameObject[] arr = new GameObject[13];
            for (int i = 0; i < 5; i++) {
                Vector3 pos = new Vector3(-7f + 3f * i, 0.5f);
                arr[i] = new_arrow(pos);
                pos.y -= 2.3f;
                arr[i + 5] = new_arrow(pos);
            }
            for (int i = 0; i < 3; i++) {
                Vector3 pos = new Vector3(-4f + 3f * i, -4.1f);
                arr[i + 10] = new_arrow(pos);
            }

            return arr;
        }

    }

}
