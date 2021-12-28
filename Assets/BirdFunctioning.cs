using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class BirdFunctioning : MonoBehaviour
{
	public static BirdFunctioning instance;
	public float speed = 0.6f;
	public List<GameObject> spawnBirdChild, usedBirdChildren;
	public bool isBird;
	
	private void Awake()
	{
		instance = this;
	}

	void Start()
	{
		usedBirdChildren = new List<GameObject>();
	}

	public void BirdTransformation()
	{
		isBird = true;
		int childNumber = CrowdController.instance.crowdList.Count;

		for (int i = childNumber; i > 0; i--)
		{
			speed = 0.5f;
			GameObject obj = CrowdController.instance.crowdList[i - 1];
			obj.GetComponent<CrowdFollow>().enabled = false;
			
			StartCoroutine(MoveToBird(obj));
		}
	}

	IEnumerator MoveToBird(GameObject child)
	{
		GameObject spawnObject = spawnBirdChild[Random.Range(0, spawnBirdChild.Count-1)];
		usedBirdChildren.Add(spawnObject);
		spawnBirdChild.Remove(spawnObject);

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
