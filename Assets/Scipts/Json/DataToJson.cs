using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataToJson : MonoBehaviour
{
    public static DataToJson instance;

    public int levelAmount;
    public CheckList list;
    [SerializeField] private int width;
    [SerializeField] private int height;

    private int dem;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Start()
    {
        //list = new CheckList[levelAmount];
        InitListCheckList();
    }

    public void InitCheckList(int level)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int tmp = Random.Range(0, 2);

                list.listCheck.Add(tmp);
            }
        }
        string str = JsonUtility.ToJson(list);
        //Debug.Log(str);
        File.WriteAllText(Application.dataPath + "/Resources/Level_" + level + ".json", str);
    }

    public void InitListCheckList()
    {
        for (int i = 0; i < levelAmount; i++)
        {
            InitCheckList(i + 1);
        }
    }
}
