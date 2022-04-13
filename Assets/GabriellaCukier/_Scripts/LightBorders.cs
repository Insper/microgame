using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GabriellaCukier {

    public class LightBorders : MonoBehaviour
    {

        public Collider m_Collider;
        public Vector3 m_Center;
        public Vector3 m_Size, m_Min, m_Max;

        public void Start()
        {
            m_Collider = GetComponent<Collider>();
            m_Min = m_Collider.bounds.min;
            m_Max = m_Collider.bounds.max;
        }

        void Update()
        {
            m_Min = m_Collider.bounds.min;
            m_Max = m_Collider.bounds.max;   
        }
    }
}

// Referência:
// https://docs.unity3d.com/ScriptReference/Collider-bounds.html