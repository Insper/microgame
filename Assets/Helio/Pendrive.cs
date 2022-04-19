using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendrive : MonoBehaviour
{
    Animator m_Animator;
    private Helio.GameManager hgm;
    private MicrogameInternal.GameManager gm;
    public bool _bad = false;
    // Start is called before the first frame update
    void Awake()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        hgm = Helio.GameManager.GetInstance();
        gm = MicrogameInternal.GameManager.GetInstance();
    }
    // Update is called once per frame
    private void OnMouseOver() {
            if(Input.GetMouseButton(0) && _bad && Helio.GameManager.click){
                // Debug.Log(gm.GetClick());
                Helio.GameManager.click = false;
                Helio.GameManager._bad = true;
                MicrogameInternal.GameManager.GetInstance().GameLost();
            } 
            else if (Input.GetMouseButton(0) && Helio.GameManager.click){
                // Debug.Log(gm.GetClick());
                Helio.GameManager.click = false;
                Invoke(nameof(Destroy),0.1f);
            } 
    }

    void Destroy(){
        Destroy(gameObject);
    }
    public void ActBad(){
        _bad = true;
        m_Animator.SetTrigger("bad");
    }
}
