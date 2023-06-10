using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static int currentLevel = 1;
    public const int maxLevel = 10;
    public static int UnlockLevel
    {
        get => PlayerPrefs.GetInt("UnlockLevel", 1);
        set => PlayerPrefs.SetInt("UnlockLevel", Mathf.Min(value, maxLevel));
    }
}
