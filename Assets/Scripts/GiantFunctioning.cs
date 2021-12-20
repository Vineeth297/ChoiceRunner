using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantFunctioning : MonoBehaviour
{
	public List<GameObject> spawnManChild;
	
	void Start()
    {
		for (int i = 0; i < spawnManChild.Count; i++)
		{
			if (!spawnManChild[i].activeInHierarchy)
			{
				spawnManChild[Random.Range(i,spawnManChild.Count)].SetActive(true);
				
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
