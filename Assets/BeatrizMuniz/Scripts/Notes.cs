using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bilbia {
    public class Notes : MonoBehaviour
    {
        public Sprite[] keys;
        private SpriteRenderer render;
        public int key;

        void Awake()
        {
            render = gameObject.GetComponent<SpriteRenderer>();
            key = Random.Range(0,3);
            render.sprite = keys[key];
        }
    }
}
