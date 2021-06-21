using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VE_TargetController : VE_SteerableBehaviour
{

    private int level;
    // Start is called before the first frame update
    void Start()
    {
        level = GameData.level;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        int multiplier = level/3;
        float newY = Mathf.Sin(Time.time * multiplier);
        float direction = newY*2.5f - pos.y;
        Thrust(0, direction);
    }
}
