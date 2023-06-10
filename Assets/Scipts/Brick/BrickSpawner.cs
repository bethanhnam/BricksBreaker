using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public static BrickSpawner instance;

    [SerializeField] private GameObject[] brickPrefabs;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float speed;
    public GameObject partical;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void SpawnBrick(CheckList _list)
    {
        int dem = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (_list.listCheck[dem] == 1)
                {
                    Instantiate(brickPrefabs[0], new Vector2(i, j), Quaternion.identity, transform);
                }
                else if (_list.listCheck[dem] == 2)
                {
                    Instantiate(brickPrefabs[1], new Vector2(i, j), Quaternion.identity, transform);
                }
                else if (_list.listCheck[dem] == 3)
                {
                    Instantiate(brickPrefabs[2], new Vector2(i, j), Quaternion.identity, transform);
                }
                else if (_list.listCheck[dem] == 4)
                {
                    Instantiate(brickPrefabs[3], new Vector2(i, j), Quaternion.identity, transform);
                }

                dem++;
            }
        }
    }

    public void MoveDown()
    {
        foreach (Transform child in transform)
        {
            Vector2 pos = child.position;
            pos.y -= 1;
            child.position = Vector2.MoveTowards(child.position, pos, speed);
        }

    }

    public GameObject GetIndexBottom()
    {
        int count = transform.childCount;

        GameObject _instance = GetFirstBrick();
        //Debug.Log("First Brick: " + _instance);

        for (int i = 0; i < count; i++)
        {
            if (transform.GetChild(i).CompareTag("Brick"))
            {
                if (transform.GetChild(i).transform.position.y < _instance.transform.position.y)
                {
                    _instance = transform.GetChild(i).gameObject;
                }
            }
        }
        return _instance;
    }
    public GameObject GetFirstBrick()
    {
        int count = transform.childCount;

        for (int i = 0; i < count; i++)
        {
            if (transform.GetChild(i).tag == "Brick")
            {
                return transform.GetChild(i).gameObject;
            }
        }
        return null;
    }

    public void Explode(Vector2 pos)
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Brick") && child.position.y == pos.y)
            {
                Brick.instance.Destroy(child.gameObject,child.transform.position);
            }
        }
    }
}
