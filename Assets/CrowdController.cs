using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CrowdController : MonoBehaviour
{
	public static CrowdController instance;
	
	public Transform lastFollower;
	public List<GameObject> crowdList;
	public Transform playerLastPosition;

	public int crowdCounter = 1;
	public GameObject playerGameObject;

	public GameObject man;
	void Awake()
	{
		instance = this;
		crowdList = new List<GameObject>();
	}

	public void spawnCrowd(int num)
	{
		print("SpawnCalled");
		if (lastFollower == null)
		{
			lastFollower = this.transform;
		}
		for (int i = 0; i < num; i++)
		{
			Vector3 spawnPos;
			if (lastFollower == null) spawnPos = transform.position;
			else spawnPos = lastFollower.position;

			GameObject manObj = ObjectPoolingScript.instance.GetPooledObjects();
			manObj.SetActive(true);
			manObj.transform.position = lastFollower.transform.position;
			CrowdFollow crowdFollow = manObj.GetComponent<CrowdFollow>();
			crowdList.Add(manObj);
			//ObjectPoolingScript.instance.objectRbList[i].position = lastFollower.transform.position;
			//manObj.transform.parent = transform;

			crowdFollow.charToFollow = lastFollower;


			crowdFollow.enabled = true;
			//crowdFollow.GetComponent<Animator>().SetTrigger("run");
			lastFollower = crowdFollow.gameObject.transform;

			//crowd.Add(crowdFollow.gameObject);
			crowdCounter += 1;
			//crowdCountText.SetText(crowdCounter.ToString());
			// other.transform.GetChild(0).GetComponent<AnimationControl>().EnableAnimation();
			//other.transform.GetChild(2).gameObject.SetActive(true);
		}
		
		
		// if (lastFollower == null)
		// {
		// 	lastFollower = this.transform;
		// }
		//
		// for (int i = 0; i < num; i++)
		// {
		// 	Vector3 spawnPos;
		// 	
		// 	GameObject manObj = ObjectPoolingScript.instance.GetPooledObjects();
		// 	manObj.SetActive(true);
		// 	manObj.transform.position = new Vector3(Random.Range(transform.position.x-1,transform.position.x + 1),transform.position.y,Random.Range(transform.position.z-1,transform.position.z + 1));
		// 	crowdList.Add(manObj);
		//
		// 	crowdCounter += 1;
		// }
	}
	
	
	public void DealCrowdEnd ()
	{
		Vector3 lookDir = playerLastPosition.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(lookDir);
		transform.rotation = Quaternion.Euler(lookRotation.eulerAngles);
		transform.DOMove(playerLastPosition.position, 1.5f).OnComplete(() =>
		{
			//StartCoroutine(FormCrowd());
			transform.eulerAngles = Vector3.zero;
			//CreatePositions();
		});
	}

}
