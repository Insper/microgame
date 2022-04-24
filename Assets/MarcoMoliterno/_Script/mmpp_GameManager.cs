using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Marcompp {
    public class mmpp_GameManager : MonoBehaviour
    {
        [SerializeField]private GameObject _instructions;
        [SerializeField]private GameObject flag;
        //[SerializeField]private GameObject _baseDot;
        //[SerializeField]private GameObject _basebDot;
        //[SerializeField] private GameObject _dotHolder;
        private MicrogameInternal.GameManager gm;

        [SerializeField]private GameObject[] levels;
        [SerializeField]private int[] flagpos = {0,1,3,4,3};

        private int _level;

        private mmpp_FlagManager fm;



        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            fm = mmpp_FlagManager.GetInstance();
            Invoke(nameof(Begin), 0.5f);
            LoadLevel();
        }


        void LoadLevel() {
            _level = gm.ActiveLevel <= 4 ? gm.ActiveLevel : 4;
            levels[_level].SetActive(true);
            
            flag.transform.position = new Vector3(flag.transform.position.x,flagpos[_level],0);
        }

        void Begin() {
            _instructions.SetActive(false);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
        }

        void EndCheck() {
           if(!fm.reached) gm.GameLost();
        }
    }
}
