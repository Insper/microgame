using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

namespace HenriqueMualem {
    public class GameManager : MonoBehaviour {

        public GameObject instructions, panel, level, spawner, levelBG, elecBG;
        private Text levelText;
        private SwitchSpawner spawnerScript;
        private int _level;
        
        private MicrogameInternal.GameManager gm;


        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            level.SetActive(false);
            levelBG.SetActive(false);
            elecBG.SetActive(false);
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            levelText = level.GetComponent<Text>();
            levelText.text = $"Faca todas as luzes ficarem verdes!";
            spawnerScript= spawner.GetComponent<SwitchSpawner>();
            switch (_level) {
                case 2:
                    spawnerScript.switchNumber = 16;
                    break;
                case 1:  
                    spawnerScript.switchNumber = 12;
                    break;
                case 0:
                    spawnerScript.switchNumber = 8;
                    break;
            }

            Invoke(nameof(Begin), 0.5f);                       
        }

        void Begin() {
            instructions.SetActive(false);
            panel.SetActive(false);
            level.SetActive(true);
            levelBG.SetActive(true);
            elecBG.SetActive(true);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
        }

        void EndCheck() {
            if(!spawnerScript.won) {
                gm.GameLost(); 
            } 
        }
    }
}
