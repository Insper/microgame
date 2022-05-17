using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace AbelCavalcante {
	public class KeyBehaviour : MonoBehaviour {
		private AbelCavalcante.GameManager gmAb;
		private bool start = false;

		public SpriteRenderer spriteRenderer;
		public Sprite[] spriteArray;
		

		void Start() {
			gmAb = Camera.main.GetComponent<AbelCavalcante.GameManager>();
		}

		void Update() {
			if (gmAb.gameState == AbelCavalcante.GameManager.GameState.BEGIN) {
				string actual_sprite = "_" + gmAb.sequence[gmAb.sequence_index].ToString();
				if (spriteRenderer.sprite == null && !start) {
					spriteRenderer.sprite = spriteArray[Array.FindIndex(spriteArray, x => x.name == actual_sprite)];
					start = true;
				}
				else if (spriteRenderer.sprite != null && spriteRenderer.sprite.name != actual_sprite) {
					StartCoroutine(BetweenKeys(actual_sprite));
				}
			} else {
				spriteRenderer.sprite = null;
			}
		}

		IEnumerator BetweenKeys(string actual_sprite) {
			spriteRenderer.sprite = null;
			yield return new WaitForSeconds(.02f);
			spriteRenderer.sprite = spriteArray[Array.FindIndex(spriteArray, x => x.name == actual_sprite)];
		}
	}
}
 