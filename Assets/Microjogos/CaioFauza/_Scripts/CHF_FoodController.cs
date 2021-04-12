using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHF_FoodController : MonoBehaviour
{
     private Rigidbody2D food;
     private Vector3 course;

    void Start()
    {
         food = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        course =  (posPlayer - transform.position).normalized;
        food.MovePosition(food.position + new Vector2(course.x*2, course.x*2) * Time.fixedDeltaTime);
    }
}
