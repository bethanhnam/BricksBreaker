using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelSelectItem : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] Button button;

    private void Start()
    {
        levelText.text = level.ToString();
    }
    public void Select()
    {
        LevelSelector.StartLevel(level);
    }

    public void SetLevel(int _level)
    {
        level = _level;
        button.interactable = PlayerDataManager.UnlockLevel >= level;
    }   

   
}
