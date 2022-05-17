using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fuka {
    public class buttonController : MonoBehaviour{
        private GameObject display;
        private Text t;
        // Start is called before the first frame update
        void Start()
        {
            display = GameObject.FindWithTag("display");
            t = display.GetComponent<Text>();
        }
        private void OnMouseDown() {
            if(gameObject.tag == "C"){
                if(t.text.Length>0){
                    t.text = t.text.Remove(t.text.Length-1);
                }
            }
            else{
                t.text += gameObject.tag;
            }
        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}