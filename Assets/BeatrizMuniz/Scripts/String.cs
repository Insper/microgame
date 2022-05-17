using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bilbia {
    public class String : MonoBehaviour
    {
        public int health;
        private int _level;
        private SpriteRenderer render;

        private MicrogameInternal.GameManager gm;

        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            health = Random.Range(1-_level, 3-_level);
            render = gameObject.GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            if(health == 1){
                render.color = new Color(1, 0.5f, 0.5f, 1);
            }
            else if(health <= 0){
                render.color = new Color(1, 0.25f, 0.25f, 1);
            }
            
        }

        public void StringDecreaseHealth()
        {
            health --;
            if (health < 0){
                gm.GameLost();
            }
        }
    }
}

// 0 > 2,1
// 1 > 1,0
// 2 > 0