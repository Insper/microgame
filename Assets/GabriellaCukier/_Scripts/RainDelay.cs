using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GabriellaCukier {
    public class RainDelay : MonoBehaviour
    {

        private ParticleSystem rainSys;
        private MicrogameInternal.GameManager gm;


        void Start(){
            gm = MicrogameInternal.GameManager.GetInstance();
            rainSys=GetComponent<ParticleSystem>();
            var mainSettings = rainSys.main;
            if (gm.ActiveLevel < 3)
                mainSettings.startDelay=2f;
            else if (gm.ActiveLevel <= 4)
                mainSettings.startDelay=1f;
            else
                mainSettings.startDelay=0f;
        }


        // Referência:
        // https://www.youtube.com/watch?v=Gi4EQ_5paNM
    }
}