using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallSpawner : MonoBehaviour
{
	public static BallSpawner instance;

	[SerializeField] private GameObject ballPrefabs;
	[SerializeField] public Transform ballSpawner;

	public int poolSize;
	public int ballCount;
	public int ballCurrent;
	[SerializeField] private TMP_Text ballCountText;
	[SerializeField] private float speed;
	[SerializeField] private float timeRate;
	private float timeElapsed = 0f;
	private float speedMultiplier = 1f;
	private const float increaseInterval = 10f;
	private const float increaseFactor = 0.2f;
	public bool canChangePosition;

	[SerializeField] private LayerMask layerMask;

	[SerializeField] private float angle;
	[SerializeField] private float angleMax;
	[SerializeField] private float angleMin;


	[SerializeField] private GameObject warningBG;


	private bool _canShooting;
	private bool _canRotating;

	private GameObject _ball_instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		ballSpawner.position = transform.position;
		ballCount = poolSize;
		ballCurrent = poolSize;
		_canShooting = true;
		_canRotating = true;
	}

	private void Update()
	{
		ballCountText.text = ballCount.ToString();

		if (_canRotating)
			CheckRotating();

		if (ballCurrent == 0)
		{
			GameManager.instance.CheckStatus();

			if (GameManager.instance.turn > 0)
				CheckReset();

		}
		if (ballCurrent == -ballCount)
		{
			CheckReset();
		}
	}

	private void FixedUpdate()
	{
		if (_canShooting && Input.GetMouseButtonUp(0))
		{
			_canRotating = false;
			GameManager.instance.turn--;
			StartCoroutine(Shooting());
			timeElapsed = 0;
		}
		if (!_canShooting)
		{
			timeElapsed += Time.fixedDeltaTime; // Tăng giá trị thời gian đã trôi qua
		}
		if (timeElapsed >= increaseInterval)
		{
			timeElapsed = 0f;
			speedMultiplier += increaseFactor; // Tăng giá trị tốc độ
			IncreaseBallSpeed();
		}
		
	}
	void IncreaseBallSpeed()
	{
		foreach (Transform child in transform)
		{
			if (child.CompareTag("Ball"))
			{
				Rigidbody2D ballRigidbody = child.GetComponent<Rigidbody2D>();
				ballRigidbody.velocity *= speedMultiplier; // Tăng tốc độ của bóng
				ballRigidbody.angularVelocity *= speedMultiplier; // Tăng tốc độ xoay của bóng
			}
		}
	}
	public void CheckRotating()
	{
		if (Input.GetMouseButton(0))
		{
			//var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//var dir = mousePos - transform.position;
			//angle = Vector2.SignedAngle(dir, Vector2.up);
			//rb.MoveRotation(-angle);

			var pos = Camera.main.WorldToScreenPoint(transform.position);
			var dir = Input.mousePosition - pos;
			angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(Mathf.Clamp(angle, angleMin, angleMax) * -1, Vector3.forward);

			//_canRotating = false;

			RaycastHit2D ray = Physics2D.Raycast(gameObject.transform.position, transform.up, 20f, layerMask);
			Vector2 reflactPos = Vector2.Reflect(new Vector3(ray.point.x, ray.point.y) - this.transform.position, ray.normal);


			if (angle >= angleMin && angle <= angleMax)
			{
				//Debug.DrawRay(gameObject.transform.position, transform.up * ray.distance, Color.red);
				//Debug.DrawRay(ray.point, reflactPos.normalized * 2f, Color.red);

				Dots.instance.DrawDottedLine(transform.position, ray.point);
				Dots.instance.DrawDottedLine(ray.point, ray.point + reflactPos.normalized * 4f);
			}
		}
	}

	IEnumerator Shooting()
	{
		int temp = poolSize;
		for (int i = 0; i < temp; i++)
		{
			yield return new WaitForSeconds(timeRate);
			_ball_instance = Instantiate(ballPrefabs, ballSpawner.position, Quaternion.identity,transform);
			ballCount--;
			_ball_instance.GetComponent<Rigidbody2D>().velocity = (transform.up * speed);
			_canShooting = false;
			if (i == temp - 1)
			{
				ballSpawner.gameObject.SetActive(false);
			}
		}


	}

	public void CheckReset()
	{
		changePosition();
		BrickSpawner.instance.MoveDown();
		CheckWarning();
		ballCount = poolSize;
		ballCurrent = poolSize;
		Padding.instance.dem = 0;
		ballSpawner.position = transform.position;
		ballSpawner.gameObject.SetActive(true);
		_canRotating = true;
		_canShooting = true;

		//transform.position = Padding.instance.newSpawnerPos;
	}
	public void CheckWarning()
	{
		GameObject _instance = BrickSpawner.instance.GetIndexBottom();
		Debug.Log("Brick bottom: " + _instance);

		if (_instance == null)
		{
			GameMenu.instance.ShowWin();
		}
		else if (_instance.transform.position.y - gameObject.transform.position.y >= 2)
		{
			if (warningBG.activeSelf)
				warningBG.SetActive(false);
		}
		else if (_instance.transform.position.y - gameObject.transform.position.y <= 0)
		{
			if (warningBG.activeSelf)
				warningBG.SetActive(false);

			GameMenu.instance.ShowLose();
		}
		else
		{
			if (!warningBG.activeSelf)
				warningBG.SetActive(true);
		}
	}

	public void CallBallBack()
	{
		//int count = transform.childCount;
		//Debug.Log(count);
		//for (int i = 0; i < count; i++)
		//{
		//    if(transform.GetChild(i).tag == ("Ball"))
		//        transform.GetChild(i).GetComponent<Rigidbody2D>().simulated = false;

		//}
		foreach (Transform child in transform)
		{
			if (child.CompareTag("Ball"))
			{
				Rigidbody2D ballRigidbody = child.GetComponent<Rigidbody2D>();
				ballRigidbody.simulated = false;

			}
		}
	}
	void changePosition()
	{
		transform.position = Padding.instance.newBallSpawner.position;
	}

}
