using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMan : MonoBehaviour
{
	public static SnakeMan instance;
	public bool isRotating;

	public int angle = 1;

	public float moveSpeed = 1f;

	
	
	public GameObject endPosition;

	void Awake()
	{
		instance = this;
	}
    void Update()
    {
		if (isRotating)
		{
			transform.Rotate(Vector3.up,angle);
			transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime) );
		}
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("EndSnaking"))
		{
			isRotating = false;
			StartCoroutine(EndSnake());
			
			PlayerMovement.instance.snakeManCamera.gameObject.SetActive(false);
		}	
	}
	
	IEnumerator EndSnake()
	{
		for (int i = 0; i < PlayerMovement.instance.snakeManList.Count; i++)
		{
			PlayerMovement.instance.snakeManList[i].SetActive(false);
			yield return new WaitForSeconds(Time.deltaTime);
		}

		PlayerMovement.instance.gameObject.transform.position = endPosition.transform.position;
		PlayerMovement.instance.isOnGround = true;
	}
	
}
