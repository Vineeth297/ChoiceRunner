using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;

public class GiantFunctioning : MonoBehaviour
{
	public static GiantFunctioning instance;
	public float speed = 0.6f;
	public List<GameObject> spawnManChild;

	void Awake()
	{
		instance = this;
	}
	
	public void GiantTransformation()
	{
		int childNumber = CrowdController.instance.crowdList.Count;
		for (int i = 0; i < CrowdController.instance.crowdList.Count; i++)
		{
			speed = 0.5f;
			GameObject obj = CrowdController.instance.crowdList[childNumber - 1];
			obj.GetComponent<CrowdFollow>().enabled = false;
			
			StartCoroutine(MoveToGiant(obj));
			childNumber--;
			if (childNumber < 0)
			{
				return;
			}
		}
	}

	IEnumerator MoveToGiant(GameObject child)
	{
		print(child);
				
		GameObject spawnObject = spawnManChild[Random.Range(0, spawnManChild.Count-1)];
		
		while (Vector3.Distance(child.transform.position,spawnObject.transform.position) > 0.001f)
		{
			child.transform.position = Vector3.Lerp(child.transform.position,spawnObject.transform.position,speed);

			if (Vector3.Distance(child.transform.position,spawnObject.transform.position) < 0.08f)
			{
				print("Here");
				spawnObject.SetActive(true);
				child.SetActive(false);
				break;
			}
			
			yield return null;
		}
	}
}
