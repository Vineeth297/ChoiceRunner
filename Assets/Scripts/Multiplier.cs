using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    // Start is called before the first frame update

	public bool hasPlayed;
	
	void OnTriggerEnter(Collider other)
	{
		if (hasPlayed) return;
		
		if (other.CompareTag("Player"))
		{
			CrowdController.instance.spawnCrowd(25);
			if (GiantFunctioning.instance.isGiant)
			{
				GiantFunctioning.instance.GiantTransformation();
			}
			if (SnakeFunctioning.instance.isSnake)
			{
				SnakeFunctioning.instance.SnakeTransformation();
			}
			if (BirdFunctioning.instance.isBird)
			{
				BirdFunctioning.instance.BirdTransformation();
			}
			hasPlayed = true;
		}
	}
}
