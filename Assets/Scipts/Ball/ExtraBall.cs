using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : MonoBehaviour
{
    [SerializeField] private int value;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            BallSpawner.instance.poolSize += value;
            Destroy(gameObject);
        }
    }
}
