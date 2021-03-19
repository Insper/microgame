using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gabrielfz_PlayerController : MonoBehaviour {
    private float velocity;

    [SerializeField] private gabrielfz_PacmanMainController main_controller;
    private Rigidbody2D rigid_body;
    private gabrielfz_Boundaries boundaries;

    void Start() {
        rigid_body = GetComponent<Rigidbody2D>();
        boundaries = GetComponent<gabrielfz_Boundaries>();
        velocity = ((6-GameData.GetTime())/6)* 40;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log($"Time: {GameData.GetTime()}");
        Debug.Log($"Velocity: {velocity}");
        move_player();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Collectable")) {
            Destroy(collision.gameObject);
        }
    }  

    void move_player() {
        if (!main_controller.has_started) return;

        float y_input = Input.GetAxis("Vertical");
        float x_input = Input.GetAxis("Horizontal");
        
        Vector2 rigid_body_position = rigid_body.position;
        Vector3 next_rigid_body_position = rigid_body_position + new Vector2(x_input*velocity, y_input*velocity) * Time.fixedDeltaTime;
        if (!boundaries.IsObjectOutOfBounds(next_rigid_body_position)) {
            rigid_body.MovePosition(next_rigid_body_position);
        }
    }
}
