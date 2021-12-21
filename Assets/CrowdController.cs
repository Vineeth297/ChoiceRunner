using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
	public static CrowdController instance;
	
	public Transform lastFollower;
	public List<GameObject> crowdList;
	public Transform playerLastPosition;

	public int crowdCounter = 1;
	public GameObject playerGameObject;

	void Awake()
	{
		instance = this;
		crowdList = new List<GameObject>();
	}

	public void spawnCrowd(int num)
	{
		if (lastFollower == null)
		{
			lastFollower = this.transform;
		}

		for (int i = 0; i < num; i++)
		{
			Vector3 spawnPos;
			
			GameObject manObj = ObjectPoolingScript.instance.GetPooledObjects();
			manObj.SetActive(true);
			manObj.transform.position = new Vector3(Random.Range(transform.position.x-1,transform.position.x + 1),transform.position.y,Random.Range(transform.position.z-1,transform.position.z + 1));
			crowdList.Add(manObj);

			crowdCounter += 1;
		}
	}

}
