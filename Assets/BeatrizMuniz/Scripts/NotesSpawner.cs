using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bilbia { 
    public class NotesSpawner : MonoBehaviour
    {
        public List<int> keys = new List<int>();
        public List<GameObject> keyObjects = new List<GameObject>();

        public GameObject Note;
        public GameObject SpaceBar;
        void Start()
        {
            SpawnNotes();
        }

        void SpawnNotes()
        {
            for(int i=0; i<4; i++){
                Vector3 position = new Vector3(-7.4f + i*2f, 1f, 0f);
                GameObject noteObj = Instantiate(Note, position, Quaternion.identity, transform);

                var noteScript = noteObj.GetComponent<Notes>();

                keys.Add(noteScript.key);
                keyObjects.Add(noteObj);
            }

            Vector3 spacePosition = new Vector3(4.8f, 3.3f, 0f);
            GameObject spaceObj = Instantiate(SpaceBar, spacePosition, Quaternion.identity, transform);

            keys.Add(4);
            keyObjects.Add(spaceObj);
        }
    }
}