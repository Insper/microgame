using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hr_PlayerController : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private float speed = 10;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {

    }

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
}
