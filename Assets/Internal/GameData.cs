using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameData
{
    public static bool debugging = false;

    static List<int> lastScenes = new List<int>();
    public static int level { get; private set; } = 0;

    public static bool lost = false;


    public static bool CanLoadScene(int buildIndex)
    {
        GameData.DebugLog($"[GameData] last loaded scenes {lastScenes.ToString()}");
        if (lastScenes.Contains(buildIndex)) return false;
        lastScenes.Insert(0, buildIndex);
        if (lastScenes.Count > Mathf.Min(SceneManager.sceneCountInBuildSettings - 3, 4))
        {
            lastScenes.RemoveAt(lastScenes.Count - 1);
        }
        level++;
        return true;
    }

    public static float GetTime()
    {
        return 5.0f - Mathf.Log10(level+1);
    }

    public static void DebugLog(string message)
    {
        if (!debugging) return;
        Debug.Log(message);
    }



}
