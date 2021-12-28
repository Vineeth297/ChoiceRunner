using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SnakeFunctioning : MonoBehaviour
{
	public static SnakeFunctioning instance;
	public List<GameObject> spawnSnakeChild,usedSnakeChildren;
	public float speed = 0.6f;
	
	public bool isSnake;

	void Awake()
	{
		instance = this;	
	}

	private void Start()
	{
		usedSnakeChildren = new List<GameObject>();
	}

	public void SnakeTransformation()
	{
		isSnake = true;
		int childNumber = CrowdController.instance.crowdList.Count;

		for (int i = childNumber; i > 0; i--)
		{
			speed = 0.5f;
			GameObject obj = CrowdController.instance.crowdList[i - 1];
			obj.GetComponent<CrowdFollow>().enabled = false;
			
			StartCoroutine(MoveToSnake(obj));
		}
	}

	IEnumerator MoveToSnake(GameObject child)
	{
		GameObject spawnObject = spawnSnakeChild[Random.Range(0, spawnSnakeChild.Count-1)];
		usedSnakeChildren.Add(spawnObject);
		spawnSnakeChild.Remove(spawnObject);

		if (!spawnObject.activeInHierarchy)
		{
			while (Vector3.Distance(child.transform.position,spawnObject.transform.position) > 0.001f)
			{
				//print("While");
				child.transform.position = Vector3.Lerp(child.transform.position,spawnObject.transform.position,speed);

				if (Vector3.Distance(child.transform.position,spawnObject.transform.position) < 0.08f)
				{
					print("Here");
					CrowdController.instance.crowdList.Remove(child);
					spawnObject.SetActive(true);
					child.SetActive(false);
					break;
				}
				yield return null;
			}	
		}
	}
}
