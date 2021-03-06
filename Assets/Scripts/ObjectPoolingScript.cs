using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingScript : MonoBehaviour
{
	public static ObjectPoolingScript instance;
	
	public GameObject objectToPool;
	public List<GameObject> objectPool;
	public int amountToPool;

	public List<Rigidbody> objectRbList;
	
	void Awake()
	{
		instance = this;
	}
	
    void Start()
    {
        objectPool = new List<GameObject>();
		GameObject obj;
			
		for (int i = 0; i < amountToPool; i++)
		{ 
			obj = Instantiate(objectToPool);
			obj.name = "child " + (i + 1);
			obj.SetActive(false);
			Rigidbody objRb = obj.GetComponent<Rigidbody>();
			objectPool.Add(obj);
			objectRbList.Add(objRb);
		}
    }

	public GameObject GetPooledObjects()
	{
		for (int i = 0; i < amountToPool; i++)
		{
			if (!objectPool[i].activeInHierarchy)
			{
				return objectPool[i];
			}
		}
		return null;
	}
	
}
