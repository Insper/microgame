//based on: https://docs.unity3d.com/ScriptReference/Transform.Rotate.html
using UnityEngine;

// Transform.Rotate example
//
// This script creates two different cubes: one red which is rotated using Space.Self; one green which is rotated using Space.World.
// Add it onto any GameObject in a scene and hit play to see it run. The rotation is controlled using xAngle, yAngle and zAngle, modifiable on the inspector.

public class CannonRotation : MonoBehaviour
{
    public float yAngle;

    public GameObject cannon;
    public GameObject bullet;
    public Transform gun;

    public float shotDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public void Shoot()
    {
        if(Time.time - _lastShootTimestamp < shotDelay) return;
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, gun.position, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetAxisRaw("Jump") != 0)
        {
            Shoot();
        }
        if (cannon.transform.rotation.eulerAngles.z < 270 && cannon.transform.rotation.eulerAngles.z >= 250){
            cannon.transform.Rotate(0, 0, yAngle, Space.World);
        }
        if (cannon.transform.rotation.eulerAngles.z > 90 && cannon.transform.rotation.eulerAngles.z <= 120){
            cannon.transform.Rotate(0, 0, -yAngle, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if ((cannon.transform.rotation.eulerAngles.z >= 270 && cannon.transform.rotation.eulerAngles.z <= 360) ||  (cannon.transform.rotation.eulerAngles.z <= 90)) 
            {
            Debug.Log(cannon.transform.rotation.eulerAngles.z);
            cannon.transform.Rotate(0, 0, -yAngle, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if ((cannon.transform.rotation.eulerAngles.z >= 270 && cannon.transform.rotation.eulerAngles.z <= 360) ||  (cannon.transform.rotation.eulerAngles.z <= 90))
            {
            Debug.Log(cannon.transform.rotation.eulerAngles.z);
            cannon.transform.Rotate(0, 0, yAngle, Space.World);
            }
        }
    }
}