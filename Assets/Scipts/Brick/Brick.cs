using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Brick : MonoBehaviour
{
    public static Brick instance;

    [SerializeField] private Color color;
    public int id;
    private GameObject partical;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
        partical = BrickSpawner.instance.partical;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;


            ScoreManager.instance.UpdateScore();

            BrickUI tmp = gameObject.GetComponentInChildren<BrickUI>();
            tmp.UpdateValueText();


            if (tmp._value <= 0)
            {
                Vector2 pos = gameObject.transform.position;
                
                if(id==1)
                {
                    BrickSpawner.instance.Explode(pos);
                }
                Destroy(gameObject, pos);
                
            }
        }
    }
    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = color;

        }
    }
    public void Destroy(GameObject _object,Vector2 pos )
    {
        Destroy(_object);
        GameObject _instance = Instantiate(partical);
        _instance.transform.position = pos;
        Destroy(_instance, 3f);
    }
}
