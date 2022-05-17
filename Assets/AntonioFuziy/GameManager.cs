using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AntonioFuziy {
    public class GameManager : MonoBehaviour {

        [SerializeField] private GameObject _instructions;
        [SerializeField] private GameObject _baseDot;
        [SerializeField] private GameObject _basebDot;
        [SerializeField] private GameObject _dotHolder;
        private MicrogameInternal.GameManager gm;
        private int[] _mushrooms = {1, 1, 2, 2, 2, 2};
        private int[] _badmushrooms = {10, 15, 15, 20, 20, 25};
        
        AudioSource soundtrack;
        
        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            soundtrack = GetComponent<AudioSource>();
            soundtrack.Play();
            Invoke(nameof(Begin), 0.5f);
            for (int i = 0; i < _mushrooms[gm.ActiveLevel]; i++) {
                GenerateMushroom(_baseDot);
            }
            
            for (int i = 0; i < _badmushrooms[gm.ActiveLevel]; i++) {
                GenerateMushroom(_basebDot);
            }
        }

        void GenerateMushroom(GameObject dot) {
            float randX = Random.Range(-4, 4);
            float randY = Random.Range(-4, 4);
            GameObject i = Instantiate(dot, new Vector3(randX, randY, 0), Quaternion.identity);
            if (!i.name.Contains("BowserMushroom")){
                i.transform.parent = _dotHolder.transform;
            }
        }

        void Begin() {
            _instructions.SetActive(false);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
        }

        void EndCheck() {
            soundtrack.Stop();
            if(_dotHolder.transform.childCount > 0){
               gm.GameLost();
            } 
        }
    }
}
