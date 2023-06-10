using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int level;
   
    private void Awake()
    {
        if (instance == null)
            instance = this;

    }

    private void Start()
    {
        Time.timeScale = 1f;
        level = PlayerDataManager.currentLevel;
        LoadLevel(level);
    }

    public void LoadLevel(int _level)
    {
        string txt = "Level_" + _level;
        TextAsset textAsset = (TextAsset)Resources.Load(txt);
        Debug.Log(textAsset);
        CheckList _list = JsonUtility.FromJson<CheckList>(textAsset.text);
        Debug.Log(_list.listCheck.Count);
        BrickSpawner.instance.SpawnBrick(_list);
    }
    public static void UnlockLevel()
    {
        if (PlayerDataManager.currentLevel >= PlayerDataManager.UnlockLevel)
        {
            PlayerDataManager.UnlockLevel = PlayerDataManager.currentLevel + 1;
        }
    }
}
