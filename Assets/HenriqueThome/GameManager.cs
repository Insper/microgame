using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Henriquethome {
    public class GameManager : MonoBehaviour {

        [SerializeField]private GameObject _instructions;
        [SerializeField]private GameObject coke;
        [SerializeField]private GameObject fanta;
        [SerializeField] private GameObject _dotHolder;
        private MicrogameInternal.GameManager gm;
        private int[] _progression = {4, 6, 8, 9, 10, 11};
        private int[] _bprogression = {2, 3, 4, 5, 6, 7};
        
        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            Invoke(nameof(Begin), 0.5f);
            for (int i = 0; i < _progression[gm.ActiveLevel]; i++) {
                NewCan(coke);
            }
            
            for (int i = 0; i < _bprogression[gm.ActiveLevel]; i++) {
                NewCan(fanta);
            }
            
        }

        void NewCan(GameObject can) {
                float randX = Random.Range(-4, 4);
                float randY = Random.Range(-4, 4);
                GameObject i = Instantiate(can, new Vector3(randX, randY, 0), Quaternion.identity);
                if (!i.name.Contains("BadDot")) i.transform.parent = _dotHolder.transform;

        }

        void Begin() {
            _instructions.SetActive(false);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
        }

        void EndCheck() {
           if(_dotHolder.transform.childCount > 0) gm.GameLost(); 
        }
        
    
    }
}
