using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGabrielNoal : MonoBehaviour
{

    // Start is called before the first frame update
    public Transform waypoint;
    public GameObject Arrow;
    public GameObject Bow;
    public float speed; 
    public int force; 
    public GameObject Target;
    public float shootDelay = 3.0f;

    


    private bool goinUp;
    private float lastShootTimestamp = 0.0f;

    
    void Start()
    {
        startWaypointPosition(); 
        goinUp = true;
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Target.GetComponent<TargetController>().gotHit == false)
        {
            moveWaypoint();
        }
    }

    private void FixedUpdate() {
        if (Time.time - lastShootTimestamp < shootDelay) return;

        if (Target.GetComponent<TargetController>().gotHit == false && Input.GetAxis("Jump") == 1)
        {
            ShootArrow();
        }
    }

    void startWaypointPosition (){
        Vector2 targetPos = Target.transform.position;
        waypoint.position = new Vector2(targetPos.x, transform.position.y);
    }

    void moveWaypoint() {
        Vector2 waypointPos = waypoint.position;
        Vector3 direction = new Vector3(0, goinUp ? 1 : -1);
        waypoint.position += direction * Time.deltaTime * speed;

        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(waypoint.position);

        if (posicaoViewport.y > 1)
        {
            goinUp = false;
        } else if (posicaoViewport.y < 0)
        {
            goinUp = true;
        }
        moveBow();
    }

    void moveBow() {
        Vector3 waypointPos = waypoint.position;
        Vector2 direction = waypointPos - transform.position;
        transform.right = new Vector2(direction.x, direction.y);
    }

    void ShootArrow() {
        lastShootTimestamp = Time.time;
        Vector3 arrowPos = new Vector3(transform.position.x, transform.position.y);
        GameObject _arrow = Instantiate(Arrow, arrowPos, Bow.transform.localRotation);
        _arrow.GetComponent<Rigidbody2D>().AddForce(transform.right * force);
    }
}
