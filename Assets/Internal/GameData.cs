#define DEBUGING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameData
{
    static List<int> lastScenes = new List<int>();
    public static int level = 0;

    public static bool lost = false;


    public static bool CanLoadScene(int buildIndex)
    {
        if (lastScenes.Contains(buildIndex)) return false;
        lastScenes.Insert(0, buildIndex);
        if (lastScenes.Count > Mathf.Min(SceneManager.sceneCountInBuildSettings - 3, 4))
        {
            lastScenes.RemoveAt(lastScenes.Count - 1);
        }
        return true;
    }

    public static float GetTime()
    {
        return 5.0f - Mathf.Log10(level+1);
    }




}
