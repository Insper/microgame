using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {
    public GameObject BladeTrailPrefab;
    public float minCuttingVelocity = 0.001f;
    GameObject currentBlaideTrail;
    bool isCutting =  false;

    Vector2 previousPosition;  

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    void Start() {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            StartCutting();
        } else if (Input.GetMouseButtonUp(0)) {
            StopCutting();
        }

        if (isCutting) {
            UpdateCut();
        }

    }

    void UpdateCut() {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = previousPosition;
        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;

        if (velocity > minCuttingVelocity) {
            circleCollider.enabled = true;
        } else {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;
    }

    void StartCutting() {
        isCutting = true;
        currentBlaideTrail = Instantiate(BladeTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }
    void StopCutting() {
        isCutting = false;
        currentBlaideTrail.transform.SetParent(null); 
        Destroy(currentBlaideTrail, 2f);
        circleCollider.enabled = false;
    }
}
