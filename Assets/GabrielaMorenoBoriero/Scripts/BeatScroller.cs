using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gabrielamb2 {
public class BeatScroller : MonoBehaviour
{
    public float beatTempo; //how fast

    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        // MicrogameInternal.GameManager.ActiveLevel
        if(MicrogameInternal.GameManager.GetInstance().ActiveLevel ==0){
            beatTempo = beatTempo;
        }else if(MicrogameInternal.GameManager.GetInstance().ActiveLevel ==1){
            beatTempo = beatTempo *1.5f;
        }else{
            beatTempo = beatTempo * 2f;
        }
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            // if(Input.anyKeyDown) //se aprtar qualquer tecla comeca o jogo
            // {
            //     hasStarted = true;
            // }

        }else{
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
        
    }
}
}