using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : SteerableBehaviour
{
    // GameManager gm;
    void Start()
    {
        // gm = GameManager.GetInstance();
        InitialThrust();
    }
    Vector3 direction;

    private void InitialThrust(){
        float rotation_z = GameObject.FindWithTag("Player").transform.rotation.eulerAngles.z;
        if (rotation_z >= 270){
            rotation_z -= 270;
        }else{
            rotation_z += 90;
        }
        Debug.Log(rotation_z);
        rotation_z = rotation_z *Mathf.PI/180;
        direction.x = Mathf.Cos(rotation_z);
        direction.y = Mathf.Sin(rotation_z);
        Debug.Log(direction.x);
        Debug.Log(direction.y);
    }

    private void Update()
    {
        // if (gm.gameState != GameManager.GameState.GAME) return;

        
        Thrust(direction.x, direction.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) return;
        IDamageable damegeable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damegeable is null))
        {
            // gm.pontos++;
            damegeable.TakeDamage();
        }
        // gameObject.SetActive(false);
        // Destroy(gameObject);
        
    }
}
