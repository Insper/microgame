using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeatrizBernardino
{
    public class boardBehaviour : MonoBehaviour
    {

        // GameObject rock;
        bool i;
        public float speed = 3.0f;
        float eulerAngZ;


        void Start()
        {
            i = false;
            // rock = gameObject.GetComponent<GameObject>();
        }
        void Update()
        {



            eulerAngZ = transform.localEulerAngles.z;
            if (eulerAngZ > 180)
                eulerAngZ -= 360;
            // print(eulerAngZ);

            if (!i)
            {

                transform.Rotate(0.0f, 0.0f, 0.5f * Time.deltaTime * speed, Space.Self);


                if (eulerAngZ > -60)
                {
                    i = true;
                }
            }
            else
            {

                transform.Rotate(0.0f, 0.0f, -0.5f * Time.deltaTime * speed, Space.Self);

                if (eulerAngZ < -120)
                {
                    i = false;
                }

            }




        }
    }
}