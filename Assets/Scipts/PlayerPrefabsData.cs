using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PlayerPrefabsData : MonoBehaviour
{
    [MenuItem("Level/Clear Level Data")]
    public static void ClearLevelData()
    {
        PlayerPrefs.DeleteKey("UnlockLevel");
    }
    [MenuItem("Level/Clear All Data")]
    public static void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
