using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Species
{
	Human,
	Creature
}

public enum CreatureType
{
	Human,
	Giant,
	Snake,
	Bird
}

public class CreatureFunctioning : MonoBehaviour
{
	public static CreatureFunctioning instance;

	public List<GameObject> reuse;
	
	public List<GameObject> giantChildren;
	public List<GameObject> snakeChildren;
	public List<GameObject> birdChildren;
	public List<GameObject> usedChildren;

	public float speed = 0.6f;
	
	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		usedChildren = new List<GameObject>();
	}

	public void CreatureTransformation(Species mySpecies, CreatureType myCreatureType)
	{
		int childNumber;
		
		if(mySpecies == Species.Human)
			childNumber = CrowdController.instance.crowdList.Count;
		else
			childNumber = usedChildren.Count;
		
		for (int i = childNumber; i > 0; i--)
		{
			speed = 0.5f;
			GameObject creatureChild;
			if (mySpecies == Species.Human)
			{
				creatureChild = CrowdController.instance.crowdList[i - 1];
				creatureChild.GetComponent<CrowdFollow>().enabled = false;
			}
			else
				creatureChild = usedChildren[i - 1];

			StartCoroutine(MoveToCreature(creatureChild,mySpecies,myCreatureType));
		}
	}


	IEnumerator MoveToCreature(GameObject child,Species mySpecies, CreatureType myCreatureType)
	{
		GameObject spawnObject = new GameObject();
		
		if (myCreatureType == CreatureType.Giant)
		{
			spawnObject = giantChildren[Random.Range(0, giantChildren.Count - 1)];
			usedChildren.Add(spawnObject);
			giantChildren.Remove(spawnObject);
		}
		if (myCreatureType == CreatureType.Snake)
		{
			spawnObject = snakeChildren[Random.Range(0, snakeChildren.Count - 1)];
			usedChildren.Add(spawnObject);
			snakeChildren.Remove(spawnObject);
		}
		if (myCreatureType == CreatureType.Bird)
		{
			spawnObject = birdChildren[Random.Range(0, birdChildren.Count - 1)];
			usedChildren.Add(spawnObject);
			birdChildren.Remove(spawnObject);
		}

		if (!spawnObject.activeInHierarchy)
		{
			var oldPosition = child.transform.localPosition;
			var oldRotation = child.transform.localRotation;
			
			while (Vector3.Distance(child.transform.position,spawnObject.transform.position) > 0.001f)
			{
				child.transform.position = Vector3.Lerp(child.transform.position,spawnObject.transform.position,GiantFunctioning.instance.speed);

				if (Vector3.Distance(child.transform.position,spawnObject.transform.position) < 0.08f)
				{
					print("Here");
					if (mySpecies == Species.Human)
						CrowdController.instance.crowdList.Remove(child);
					else
						usedChildren.Remove(child); 
					
					spawnObject.SetActive(true);
					child.SetActive(false);
					break;
				}
				yield return null;
			}

			child.transform.localPosition = oldPosition;
			child.transform.localRotation = oldRotation;
		}
	}
}

