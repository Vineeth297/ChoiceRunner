using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
	[SerializeField] private List<Transform> spawnPositionList;

	[SerializeField] private GameObject spawnObj;

	private float[] angles = new[] {0f,-90f};
	
    void Start()
	{
		
		for (int i = 0; i < spawnPositionList.Count; i++)
		{
			GameObject obj = Instantiate(spawnObj);
			obj.transform.position = spawnPositionList[i].position;
			obj.transform.rotation = Quaternion.Euler(angles[Random.Range(0,angles.Length)],0f,0f);
			obj.transform.parent = spawnPositionList[i].transform;
		}
	}
}
