using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Emil {
	public class GameManager : MonoBehaviour {

		[SerializeField]private GameObject _instructions;
		[SerializeField]private GameObject _baseDot;
		[SerializeField]private GameObject _basebDot;
		[SerializeField] private GameObject _dotHolder;
		private MicrogameInternal.GameManager gm;
		private int[] _progression = {2, 3, 5, 4, 3, 2};
		private int[] _bprogression = {1, 1, 2, 3, 5, 5};
		
		void Start() {
			gm = MicrogameInternal.GameManager.GetInstance();
			Invoke(nameof(Begin), 0.5f);
			for (int i = 0; i < _progression[gm.ActiveLevel]; i++) {
				NewDotAtRandomPosition(_baseDot);
			}
			
			for (int i = 0; i < _bprogression[gm.ActiveLevel]; i++) {
				NewDotAtRandomPosition(_basebDot);
			}
			
		}

		void NewDotAtRandomPosition(GameObject dot) {
				float randX = Random.Range(-4, 4);
				float randY = Random.Range(-4, 4);
				GameObject i = Instantiate(dot, new Vector3(randX, randY, 0), Quaternion.identity);
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
