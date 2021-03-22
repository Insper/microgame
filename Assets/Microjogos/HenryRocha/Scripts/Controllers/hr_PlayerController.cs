using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hr_PlayerController : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private float speed = 10;

    public hr_GameController controller;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // Get the current direction.
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Change the player's position.
        transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * speed;
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Objective")
        {
            Debug.Log("Player hit the objective.");
            controller.SetGameDataLost(false);
        }
    }
}
