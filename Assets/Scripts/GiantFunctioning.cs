using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;

public class GiantFunctioning : MonoBehaviour
{
	public static GiantFunctioning instance;
	
	public List<GameObject> spawnManChild;

	void Awake()
	{
		instance = this;
	}
	
	public void GiantTransformation()
	{
		//CrowdController.instance.crowdList[4].transform.parent = this.transform;
		CrowdController.instance.crowdList[4].transform.DOMove(spawnManChild[105].transform.localPosition, 3f);
		spawnManChild[105].SetActive(true);
		// CrowdController.instance.crowdList[4].SetActive(false);
		
		//move the children to the manchild positions
		//after moving set children active to false and set the manchild at that position to active true...
		// for (int i = 0; i < CrowdController.instance.crowdCounter; i++)
		// {
		// 	if (!spawnManChild[i].activeInHierarchy)
		// 	{
		// 		
		// 		GameObject spawnObject = spawnManChild[Random.Range(0, spawnManChild.Count)];
		// 		var child = spawnObject;
		// 		var obj = CrowdController.instance.crowdList[i] ;
		// 		obj.transform.DOMove(child.transform.position, 1f).OnComplete(() =>
		// 		{
		// 			spawnObject.SetActive(true);	
		// 			obj.SetActive(false);
		// 		});
		// 		
		// 		
		// 	}
		// }
	}
	
}
