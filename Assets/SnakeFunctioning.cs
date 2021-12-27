using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SnakeFunctioning : MonoBehaviour
{
	public static SnakeFunctioning instance;
	public List<GameObject> spawnSnakeChild;
	public float speed = 0.6f;

	void Awake()
	{
		instance = this;
	}
	
	public void SnakeTransformation()
	{
		int childNumber = CrowdController.instance.crowdList.Count;
		for (int i = 0; i < childNumber; i++)
		{
			speed = 0.5f;
			GameObject obj = CrowdController.instance.crowdList[childNumber - 1];
			obj.GetComponent<CrowdFollow>().enabled = false;
			
			StartCoroutine(MoveToSnake(obj));
			childNumber--;
			if (childNumber < 0)
			{
				return;
			}
		}
	}

	IEnumerator MoveToSnake(GameObject child)
	{
		GameObject spawnObject = spawnSnakeChild[Random.Range(0, spawnSnakeChild.Count - 1)];
		while (Vector3.Distance(child.transform.position, spawnObject.transform.position) > 0.001f)
		{
			child.transform.position = Vector3.Lerp(child.transform.position, spawnObject.transform.position, speed);
			if (Vector3.Distance(child.transform.position, spawnObject.transform.position) < 0.08f)
			{
				spawnObject.SetActive(true);
				child.SetActive(false);
				break;
			}
		}

		yield return null;
	}
}
