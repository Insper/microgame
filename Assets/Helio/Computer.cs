using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    Animator m_Animator;
    public bool _bad;
    public bool _good;
    public bool _transition;
    // Start is called before the first frame update
    void Awake()
    {
        m_Animator = gameObject.GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActBad(){
        m_Animator.SetTrigger("bad");
    }
    public void ActGood(){
        m_Animator.SetTrigger("good");
    }
}
