using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{


    [SerializeField] private GameObject levelItemPrefabs;
    [SerializeField] private Transform levelItemContainer;
    [SerializeField] private int levelAmount;
    private void Start()
    {
        LoadLevelItem();
    }
    public void LoadLevelItem()
    {
        for (int i = 0; i < levelAmount; i++)
        {
            GameObject _instance = Instantiate(levelItemPrefabs, levelItemContainer);
            _instance.GetComponent<LevelSelectItem>().SetLevel(i + 1);
        }
    }

    public static void StartLevel(int _level)
    {
        PlayerDataManager.currentLevel = _level;
        SceneManager.LoadScene("SampleScene");
    }
}
