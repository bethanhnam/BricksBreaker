using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BrickUI : MonoBehaviour
{

    public static BrickUI instance;
    [SerializeField] private int value;

    [SerializeField] private TMP_Text text;

    public int _value;

    private void Awake()
    {
        instance = this;
        text = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        //value = Random.Range(3, 5);
        GameManager.instance.totalValue += value;
        _value = value;
        text.text = _value.ToString();
    }
    public void UpdateValueText()
    {
        _value--;
        text.text = _value.ToString();
    }
}
    
