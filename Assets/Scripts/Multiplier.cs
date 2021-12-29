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
			if(PlayerMovement.instance.CurrentSpecies == Species.Human)
				CrowdController.instance.spawnCrowd(100);

			if (PlayerMovement.instance.CurrentSpecies == Species.Creature)
			{
				print("2nd Loop");
				CrowdController.instance.spawnCrowd(50);
				CreatureFunctioning.instance.CreatureTransformation(PlayerMovement.instance.CurrentSpecies,PlayerMovement.instance.currentCreatureType);				
			}
			
			hasPlayed = true;
		}
	}
}
