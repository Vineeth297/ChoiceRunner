using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
	[SerializeField] private List<Transform> spawnPositionList;

	[SerializeField] private GameObject spawnObj;
	
    void Start()
	{
		
		for (int i = 0; i < spawnPositionList.Count; i++)
		{
			GameObject obj = Instantiate(spawnObj);
			obj.transform.position = spawnPositionList[i].position;
		}
	}
}
