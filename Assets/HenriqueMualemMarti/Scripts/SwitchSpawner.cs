using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 

namespace HenriqueMualem {
    public class SwitchSpawner : MonoBehaviour {
        public GameObject switchObject;
        public GameObject wireObject;
        public float switchNumber = 16;
        public bool won = false;
        private const int squareSize = 8;
        private const int squareSizeOffset = squareSize + 5;
        private int objectNum = 0;
        private int run = 0;
        private int toComplete;
        private bool previousOn = false;
        private GameObject spawnedObject;
        GameObject[] spawnedList = new GameObject[(squareSizeOffset) * squareSize];
        WireBehavior wireBehaviorScript;
        SwitchBehavior switchBehaviorScript;
        PrivateTag privateTagScript;

        void Start() {
            toComplete = squareSizeOffset;
            for (int x = -6; x < squareSize - 1; x++) {
                for (int y = -4; y < squareSize - 4; y++) {
                    float rand = Random.Range(0, squareSize * squareSize);
                    if (y == -4 || y == 3) rand = switchNumber;
                    if (rand < switchNumber) {
                        spawnedObject = Instantiate(switchObject, new Vector3(x, y, 0), Quaternion.identity);
                        spawnedObject.transform.parent = transform;
                        switchBehaviorScript = spawnedObject.GetComponent<SwitchBehavior>();
                        if (rand < switchNumber / 4) switchBehaviorScript.isOn = true;
                        else switchBehaviorScript.isOn = false;
                        privateTagScript = spawnedObject.GetComponent<PrivateTag>();
                        privateTagScript.name = "Switch";
                    }
                    else {
                        spawnedObject = Instantiate(wireObject, new Vector3(x, y, 0), Quaternion.identity);
                        spawnedObject.transform.parent = transform;
                        privateTagScript = spawnedObject.GetComponent<PrivateTag>();
                        privateTagScript.name = "Wire";
                        if (objectNum % squareSize == 0) {
                            wireBehaviorScript = spawnedObject.GetComponent<WireBehavior>();
                            wireBehaviorScript.wireType = 0;
                        }
                        else if (objectNum % squareSize == 7) {
                            wireBehaviorScript = spawnedObject.GetComponent<WireBehavior>();
                            wireBehaviorScript.wireType = 2;
                        }
                    }
                    spawnedList[objectNum] = spawnedObject;
                    objectNum++;
                }
            }
        }

        void Update() {
            objectNum = 0;
            if (run == 10) {
                run = 0;
                foreach (GameObject tempObject in spawnedList) {
                
                    privateTagScript = tempObject.GetComponent<PrivateTag>();
                    if (privateTagScript.name == "Switch") {
                        switchBehaviorScript = tempObject.GetComponent<SwitchBehavior>();
                        if (!switchBehaviorScript.isOn && !previousOn) {
                            previousOn = true;
                        }
                        else if (!switchBehaviorScript.isOn && previousOn) {
                            previousOn = false;
                        }
                    }
                    else if (privateTagScript.name == "Wire") {
                        wireBehaviorScript = tempObject.GetComponent<WireBehavior>();
                        
                        if (objectNum == 0) previousOn = true;
                            
                        if (previousOn) {
                            wireBehaviorScript.isOn = true;
                            wireBehaviorScript.run = true;
                        }

                        else {
                            wireBehaviorScript.isOn = false;
                            previousOn = false;
                        }
                        
                        if (objectNum == squareSize - 1  && wireBehaviorScript.isOn) toComplete--;
                    }
                    if (objectNum < squareSize - 1) {
                        objectNum++;
                    } else objectNum = 0;
                }
            }
            else run++;

            if (toComplete == 0 || toComplete == -10 || toComplete == -10 - squareSizeOffset) {
                toComplete = -10;
            } else toComplete = squareSizeOffset;

            won = toComplete == -10 ? true : false;
        }
    }
}
