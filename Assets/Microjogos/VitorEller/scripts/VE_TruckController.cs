using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VE_TruckController : VE_SteerableBehaviour
{

    public GameObject shoot;
    public Transform gun;
    private bool shot = false;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        level = GameData.level/10;
    }

    // Update is called once per frame
    void Update()
    {
        float yInput = Input.GetAxis("Vertical");
        Thrust(0, yInput*(level+1));
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
