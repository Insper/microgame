// Detecção de Teclas: https://answers.unity.com/questions/165878/how-to-detect-which-key-is-pressed.html
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AbelCavalcante {
	public class GameManager : MonoBehaviour {
		[SerializeField]
		private GameObject _instructions, _ganhou;
		private MicrogameInternal.GameManager gm;
		private int _level;

		public enum GameState {START, BEGIN, ENDGAME};
		public GameState gameState { get; private set; }

		public enum Keys {UpArrow, DownArrow, LeftArrow, RightArrow, Space, W, A, S, D};
		public Keys[] sequence { get; private set; }

		public int sequence_index { get; private set; }
		private int sequence_size = 10;
		private int lifes = 1;

		void Start() {
			gm = MicrogameInternal.GameManager.GetInstance();
			gameState = GameState.START;
			Invoke(nameof(Begin), 0.5f);
		}

		void Begin() {
			_instructions.SetActive(false);
			gameState = GameState.BEGIN;
			Invoke(nameof(EndCheck), gm.MaxTime-0.1f);

			sequence_index = 0;
			sequence = CreateNewSequence();
			gm.StartTimer();
		}

		void Update() {
			if (gameState == GameState.BEGIN) {
				string key = DetectInput();
				if (key == sequence[sequence_index].ToString()) {
					sequence_index++;
				}
				else if (key != "") {
					lifes--;
					if (lifes == 0) {
						gameState = GameState.ENDGAME;
					}
				}

				if (sequence_index == sequence_size) {
					gameState = GameState.ENDGAME;
				}
			}
			else if (gameState == GameState.ENDGAME) {
				if (sequence_index == sequence_size) {
					_ganhou.SetActive(true);
				} else {
					gm.GameLost();
				}
			}
		}

		void EndCheck() {
			if(sequence_index != sequence_size){
				gm.GameLost(); 
			}
		}

		Keys[] CreateNewSequence() {
			if (gm.MaxTime == 1) {
				sequence_size = 2;
			} else{
				sequence_size = (int)(gm.MaxTime * 1.5f);
			}
			
			Keys[] k = new Keys[sequence_size];
			int max_rand = 0;
			for (int i = 0; i < sequence_size; i++) {
				if (gm.ActiveLevel < 1) {
					max_rand = Random.Range(0, 4);
				} else if (gm.ActiveLevel <= 2) {
					max_rand = Random.Range(0, 5);
				} else {
					max_rand = Random.Range(0, 8);
				}
				k[i] = (Keys)max_rand;
				if (i > 0) {
					if (k[i] == k[i - 1]) {
						i--;
					}
				}
			}
			return k;
		}

		string DetectInput() {
			string mouseClick = "Mouse[0-9]";
			foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
				if(Input.GetKeyDown(vKey)){
					if (!System.Text.RegularExpressions.Regex.IsMatch(vKey.ToString(), mouseClick)) {
						return vKey.ToString();
					}
				}
			}
			return "";
		}
	}
}
