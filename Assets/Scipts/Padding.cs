using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padding : MonoBehaviour
{
    [SerializeField] private GameObject ballSpawner;
    public static Padding instance;
     public Transform newBallSpawner;


	public int dem;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ballSpawner = GameObject.Find("BallSpawner");
	}
	public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            col.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            if (dem==0)
            {
                newBallSpawner.position = col.gameObject.transform.position;
                //Debug.Log(newBallSpawner.name + "!!!");
                //ballSpawner.transform.position = newBallSpawner.transform.position;
                dem++;
            }


        }
    }

}
