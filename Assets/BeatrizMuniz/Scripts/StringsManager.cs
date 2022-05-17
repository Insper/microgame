using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bilbia {
    public class StringsManager : MonoBehaviour
    {
        private List<int> strings = new List<int>();
        private List<GameObject> stringsObj = new List<GameObject>();
        public GameObject gameplay;
        private int currentIndex;

        void Start()
        {
            foreach(Transform child in transform){
                strings.Add(child.GetComponent<String>().health);
                stringsObj.Add(child.gameObject);
            }
        }

        public void DamageString(){
            currentIndex = gameplay.GetComponent<Gameplay>().currentKeyIndex;
            stringsObj[currentIndex].GetComponent<String>().StringDecreaseHealth();
        }
    }
}
