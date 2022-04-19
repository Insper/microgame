using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Helio {
    public class GameManager : MonoBehaviour {

        // [SerializeField]private GameObject _instructions;
        [SerializeField]private GameObject _pendrive;
        [SerializeField]private GameObject _computer;
        private MicrogameInternal.GameManager gm;
        private int[] _bprogression = {2, 4, 5};
        private int[] _progression = {1, 1, 2};
		private List<float> _list1 = new List<float>() {-0.8f,0.7f,2.2f};
		private List<float> _list2 = new List<float>() {-2.3f,-0.8f,0.7f,2.2f,3.7f};
		private List<float> _list3 = new List<float>() {-3.8f,-2.3f,-0.8f,0.7f,2.2f,3.7f,5.2f};
        private List<float> _listU = new List<float>();
        private List<GameObject> _listPendrives = new List<GameObject>();
	    public static bool click = true;
        Vector3 penR = new Vector3(0.0f,0.0f,0.0f);
        Vector3 penP = new Vector3(0.0f,0.0f,0.0f);
        int r;
        int p;
        bool p1 = true;
        bool p2 = true;
        public static bool _bad = false;
		
		#region Static Region
        private static GameManager _instance;
        public static GameManager GetInstance() {
            if (_instance == null) {
                _instance = new GameManager();
            }

            return _instance;
        }
        #endregion
        
        void Awake() {
            gm = MicrogameInternal.GameManager.GetInstance();
            int lvl = gm.ActiveLevel;
            switch (lvl){
                case 0:
                _listU = _list1;
                break;
                case 1:
                _listU = _list2;
                break;
                case 2:
                _listU = _list3;
                break;

            }
            for (int i = 0; i < _progression[lvl]; i++) {
                NewPendrive(_pendrive,lvl,false);
            }
            
            for (int i = 0; i < _bprogression[lvl]; i++) {
                NewPendrive(_pendrive,lvl,true);
            }
            StartCoroutine(Example());
        }
        void Start(){
            Invoke(nameof(Begin), 5.0f);
        }

        void Update(){
            // if(Helio.GameManager.click&&!_bad){
            //     _computer.GetComponent<Computer>().ActBad();
            // }
        }

        IEnumerator Example()
        {
            yield return new WaitForSeconds(2f);
            Debug.Log(_listPendrives.Count);
            
            for (int p = 0; p < _listPendrives.Count; p++){
                r = Random.Range(0, _listPendrives.Count);
                // while (_listPendrives[r].transform.position.x - _listPendrives[p].transform.position.x >=1.5f){
                //     r = Random.Range(0, _listPendrives.Count);
                // }
                if (_listPendrives[r].transform.position.x - _listPendrives[p].transform.position.x > 0.5f){
                    if(r-1>=0){
                        r -=1;
                    }else{
                        r +=1;
                    }
                }
                
                p1 = true;
                p2 = true;
                penR = _listPendrives[r].transform.position;
                penP = _listPendrives[p].transform.position;
                while(p1||p2){
                    yield return new WaitForSeconds(0.2f);
                    someAni(penR,penP);
                }
                Debug.Log(_listPendrives[r].transform.position.x);
                Debug.Log(_listPendrives[p].transform.position.x);
                _listPendrives = Swap(_listPendrives,r,p);
                Debug.Log(_listPendrives[r].transform.position.x);
                Debug.Log(_listPendrives[p].transform.position.x);
                yield return new WaitForSeconds(0.2f);
            }
        }
        void someAni(Vector3 pR,Vector3 pP){
            if(pR.x>pP.x){
                _listPendrives[r].transform.position = _listPendrives[r].transform.position - new Vector3(0.5f,0,0);
                _listPendrives[p].transform.position = _listPendrives[p].transform.position + new Vector3(0.5f,0,0);
                if(_listPendrives[r].transform.position.x-pP.x<=0.01f){
                    p1 = false;
                    _listPendrives[r].transform.position = pP;
                }
                if(_listPendrives[p].transform.position.x-pR.x>=-0.01f){
                    p2 = false;
                    _listPendrives[p].transform.position = pR;
                }
            }else if (pR.x<pP.x){
                _listPendrives[r].transform.position = _listPendrives[r].transform.position + new Vector3(0.5f,0,0);
                _listPendrives[p].transform.position = _listPendrives[p].transform.position - new Vector3(0.5f,0,0);
                if(_listPendrives[r].transform.position.x>=pP.x){
                    p1 = false;
                    _listPendrives[r].transform.position = pP;
                }
                if(_listPendrives[p].transform.position.x<=pR.x){
                    p2 = false;
                    _listPendrives[p].transform.position = pR;
                }
            }
        }

        //  https://stackoverflow.com/questions/2094239/swap-two-items-in-listt
        private static List<GameObject> Swap(List<GameObject> list, int indexA, int indexB)
        {
            GameObject tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }

        void NewPendrive(GameObject pendrive,int level,bool bad) {
			int randX = 1;
			float tmp = 0.0f;
			switch(level){
				case 0:
				randX = Random.Range(0, _list1.Count);
				tmp = _list1[randX];
				_list1.RemoveAt(randX);
				break;
				case 1:
				randX = Random.Range(0, _list2.Count);
				tmp = _list2[randX];
				_list2.RemoveAt(randX);
				break;
				case 2:
				randX = Random.Range(0, _list3.Count);
				tmp = _list3[randX];
				_list3.RemoveAt(randX);
				break;
			}
			GameObject i = Instantiate(pendrive, new Vector3(tmp, -3, 0), Quaternion.identity);
            _listPendrives.Add(i);
			if (bad)
			{
				i.GetComponent<Pendrive>().ActBad();
			}
        }

        void Begin() {
            // _instructions.SetActive(false);
            if(_bad){
                _computer.GetComponent<Computer>().ActBad();
                Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            }
            
            gm.StartTimer();
        }

        public void EndCheck() {
            gm.GameLost();
        }
    }
}
