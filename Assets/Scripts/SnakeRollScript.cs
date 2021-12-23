using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SnakeRollScript : MonoBehaviour
{
	public GameObject cube;
	public float moveSpeed = 0.2f, intervalZ = 0.2f;

	private Vector3 lastpos = Vector3.negativeInfinity;
	private float _prevPoZ;
	public int maxCubes = 100;

	void Start()
	{
		//cube.transform.position = 
		StartCoroutine(DoSnake());



	}


	IEnumerator DoSnake()
	{
		var currentTime = 0f;
		do
		{
			var candidate = new Vector3(
				Mathf.Sin(currentTime),
				Mathf.Cos(currentTime),
				_prevPoZ);

			if (Vector3.Distance(lastpos, candidate) < 0.3f)
			{
				_prevPoZ += intervalZ;
				currentTime += Time.deltaTime * moveSpeed;
				yield return new WaitForSeconds(Time.deltaTime * moveSpeed);
				
				continue;
			}

			GameObject obj = Instantiate(cube);
			lastpos = obj.transform.position = candidate;
			//obj.transform.parent = transform;
			
			if(maxCubes-- < 0) yield break;
			
			_prevPoZ += intervalZ;
			currentTime += Time.deltaTime * moveSpeed;
			yield return new WaitForSeconds(Time.deltaTime * moveSpeed);
		} while (true);

	}

	
}	
