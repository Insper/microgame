using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessBehaviour : MonoBehaviour
{
    private Camera cam;
    private float minH, maxH;
    Vector3 dir;
    private float speed = 10.0f;
    void Start()
    {
        //https://answers.unity.com/questions/230190/how-to-get-the-width-and-height-of-a-orthographic.html
        cam = Camera.main;
        float heightCamera = 2f * cam.orthographicSize;

        minH = cam.transform.position.y - heightCamera / 2;
        maxH = cam.transform.position.y + heightCamera / 2;

        dir = new Vector3(0, 1).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 positionVP = Camera.main.WorldToViewportPoint(transform.position);

        if (positionVP.y >= 0.85)
        {
            dir = new Vector3(dir.x, -Mathf.Abs(dir.y));
        }
        else if (positionVP.y <= 0.15)
        {
            dir = new Vector3(dir.x, Mathf.Abs(dir.y));
        }

        transform.position += dir * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
        GameData.lost = true;
    }
}
