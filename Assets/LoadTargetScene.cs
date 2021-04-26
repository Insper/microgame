using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTargetScene : MonoBehaviour
{

    public int sceneID;

    public void Load()
    {
        SceneManager.LoadScene(sceneID);
    }
}
