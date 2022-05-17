using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Fuka {
    public class GameManager : MonoBehaviour {

        [SerializeField]private AudioClip _win;
        [SerializeField]private GameObject _instructions;
        [SerializeField]private GameObject[] _guloseimas;
        [SerializeField]private List<GameObject> _spots;
        [SerializeField]private GameObject[] _placas;
        [SerializeField]private GameObject _display;
        [SerializeField]private GameObject _bilbs;
        private Text _displayText;
        [SerializeField]private GameObject[] _buttons;
        private MicrogameInternal.GameManager gm;
        public int[] _wordSize = {2, 2, 3, 3, 3, 3};
        private int[] _nGuloseimas = {7, 9, 6, 8, 10};
        private List<int> _available;
        private char[] _chars = {'1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B'};
        private string correct;
        private bool _won;
        
        void Start() {
            _won = false;
            _available = new List<int>();
            for(int i = 0; i<12; i++){
                _available.Add(i);
            }
            gm = MicrogameInternal.GameManager.GetInstance();
            for(int i = 0; i <= _nGuloseimas[gm.ActiveLevel]; i++){
                int _spotIndex = Random.Range(0, _available.Count-1);
                for(int j = 0; j <_wordSize[gm.ActiveLevel]; j++){
                    _placas[_available[_spotIndex]].GetComponent<Text>().text += _chars[Random.Range(0, _chars.Length-1)];
                }
                if(i == 0){
                    Instantiate(_guloseimas[0], _spots[_available[_spotIndex]].transform.position, Quaternion.identity);
                    correct = _placas[_available[_spotIndex]].GetComponent<Text>().text;
                }
                else{
                    Instantiate(_guloseimas[Random.Range(1,_guloseimas.Length-1)], _spots[_available[_spotIndex]].transform.position, Quaternion.identity);
                }
                _available.RemoveAt(_spotIndex);
            }
            _displayText = _display.GetComponent<Text>();
            Invoke(nameof(Begin), 0.5f);
        }

        void Begin() {
            _instructions.SetActive(false);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
            gameObject.GetComponent<AudioSource>().Play();
        }

        void EndCheck() {
            if(_displayText.text != correct){
                gm.GameLost();
            }
        }

        void Update(){
            if(_displayText.text == correct && _won != true){
                foreach (GameObject button in _buttons){
                    button.GetComponent<Collider2D>().enabled = false;
                }
                gameObject.GetComponent<AudioSource>().Pause();
                gameObject.GetComponent<AudioSource>().clip = _win;
                gameObject.GetComponent<AudioSource>().Play();
                _bilbs.GetComponent<Animator>().SetBool("win", true);
                _won = true;
            }
        }
    }
}
