using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject ballSpawner;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public static Ball instance;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void Start()
    {
        ballSpawner = GameObject.Find("BallSpawner");
    }
    private void FixedUpdate()
    {
        Move();
        BallOutCheck();
    }
    public void Move()
    {
        if (!rb.simulated)
        {
            transform.position = Vector2.MoveTowards(transform.position, ballSpawner.transform.position, speed *2);
            if(transform.position == ballSpawner.transform.position)
            {
                BallSpawner.instance.ballCurrent--;
                BallSpawner.instance.ballCount++;
                Destroy(gameObject);
            }
        }

    }
    public void BallOutCheck()
    {
        if( transform.position.y < - 20 || transform.position.y > 100 || transform.position.x < - 1 || transform.position.x > 10)
        {
            Debug.Log("out");
            BallSpawner.instance.ballCurrent--;
            BallSpawner.instance.ballCount++;
            Destroy(gameObject);
        }    
    }    
   
}
