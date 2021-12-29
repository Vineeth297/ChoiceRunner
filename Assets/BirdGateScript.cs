using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGateScript : MonoBehaviour
{
	public bool isUsed;
	
	void OnTriggerEnter(Collider other)
	{
		if (isUsed) return;

		if (other.CompareTag("Player"))
		{
			//print("player came here");
			//BirdFunctioning.instance.BirdTransformation();
			
			isUsed = true;	
		}
	}
}
