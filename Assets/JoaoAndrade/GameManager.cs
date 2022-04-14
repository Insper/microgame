using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace JoaoAndrade {
    public class GameManager : MonoBehaviour {

        private MicrogameInternal.GameManager gm;
        private SpriteRenderer spriteRenderer;
        [SerializeField]private GameObject _instructions;
        [SerializeField]private GameObject _instructionsTarget;

        [SerializeField]private GameObject _youWon;
        private int[] _progression = {2, 3, 5, 4, 3, 2};
        private int[] _bprogression = {1, 1, 2, 3, 5, 5};

        private bool _won = false;

        private string[] _possibleStrings = {"AZUL", "VERMELHO", "VERDE",  "AMARELO", "PRETO", "BRANCO", "ROSA"};

        private string[] _possibleShapes = {"Triangulo", "Circulo", "Quadrado"};
        private Color[] _possibleColors = {Color.blue, Color.red, Color.green, Color.yellow, Color.black, Color.white, Color.magenta};

        public Text colorText;

        public Text shapeText;

        private int _level;

        public GameObject[] triangulos;
        public GameObject[] circulos;
        public GameObject[] quadrados;

        
        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            if(gm.ActiveLevel == 0){
                _level = 2;
            }
            else if (gm.ActiveLevel == 1){
                _level = 1;
            }
            else{
                _level = 0;
            }
            colorText.text = _possibleStrings[Random.Range(0,_possibleStrings.Length )].ToString();
            shapeText.text = _possibleShapes[Random.Range(0,_possibleShapes.Length - _level)].ToString();
            colorText.color = _possibleColors[Random.Range(0,_possibleColors.Length)];
            shapeText.color =  Color.white;
            _instructionsTarget.SetActive(false);
            _youWon.SetActive(false);
            Invoke(nameof(Begin), 1.0f);
        }



        public void DestroyTarget(Target target){
            if(target.GetComponent<Renderer>().material.color != colorText.color || target.tag != shapeText.text){
                Destroy(target.gameObject);
                gm.GameLost();
            }
            else{
                _won = true;
                Destroy(target.gameObject);
                triangulos = GameObject.FindGameObjectsWithTag("Triangulo");
                foreach(GameObject triangulo in triangulos){
                    triangulo.SetActive(false);
                }
                circulos = GameObject.FindGameObjectsWithTag("Circulo");
                foreach(GameObject circulo in circulos){
                    circulo.SetActive(false);
                }
                quadrados = GameObject.FindGameObjectsWithTag("Quadrado");
                foreach(GameObject quadrado in quadrados){
                    quadrado.SetActive(false);
                }
                _youWon.SetActive(true);
            }
             
        }




        void Begin() {
            _instructionsTarget.SetActive(true);
            _instructions.SetActive(false);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer();  
        }

        void EndCheck() {
           if(!_won) gm.GameLost(); 
        }
        
        


    }
}
