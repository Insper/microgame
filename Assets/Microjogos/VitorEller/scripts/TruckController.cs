using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : SteerableBehaviour
{

    public GameObject shoot;
    public Transform gun;
    private bool shot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yInput = Input.GetAxis("Vertical");
        Thrust(0, yInput);
        if (Input.GetAxis("Jump") != 0) {
                Shoot();
        }
    }

    public void Shoot()
    {
        if (!shot) {
            Instantiate(shoot, gun.position, Quaternion.identity);
            shot = true;
        }
    }
}
