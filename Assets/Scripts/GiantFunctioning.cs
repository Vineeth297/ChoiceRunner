using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantFunctioning : MonoBehaviour
{
	public static GiantFunctioning instance;
	public float speed = 0.6f;
	public List<GameObject> spawnManChild, usedGiantManChildren;
	public bool isGiant;

	void Awake()
	{
		instance = this;	
	}

	private void Start()
	{
		usedGiantManChildren = new List<GameObject>();
	}

	public void GiantTransformation()
	{
		isGiant = true;
		int childNumber = CrowdController.instance.crowdList.Count;

		for (int i = childNumber; i > 0; i--)
		{
			speed = 0.5f;
			GameObject obj = CrowdController.instance.crowdList[i - 1];
			obj.GetComponent<CrowdFollow>().enabled = false;
			
			StartCoroutine(MoveToGiant(obj));
		}
	}

	IEnumerator MoveToGiant(GameObject child)
	{
		GameObject spawnObject = spawnManChild[Random.Range(0, spawnManChild.Count-1)];
		usedGiantManChildren.Add(spawnObject);
		spawnManChild.Remove(spawnObject);

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
