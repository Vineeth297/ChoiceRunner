using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public CreatureType MyCreatureType = CreatureType.Human;
	
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

	public void CreatureTransformation()
	{
		int childNumber = CrowdController.instance.crowdList.Count;
		for (int i = childNumber; i > 0; i--)
		{
			speed = 0.5f;
			GameObject creatureChild = CrowdController.instance.crowdList[i - 1];
			creatureChild.GetComponent<CrowdFollow>().enabled = false;
			
			
		//	StartCoroutine(MoveToCreature(creatureChild));
		}
	}


	IEnumerator MoveToCreature(List<GameObject> unUsedChildren,List<GameObject> usedChildren,GameObject child)
	{
		GameObject spawnObject = SnakeFunctioning.instance.spawnSnakeChild[Random.Range(0, SnakeFunctioning.instance.spawnSnakeChild.Count-1)];
		SnakeFunctioning.instance.usedSnakeChildren.Add(spawnObject);
		SnakeFunctioning.instance.spawnSnakeChild.Remove(spawnObject);

		if (!spawnObject.activeInHierarchy)
		{
			while (Vector3.Distance(child.transform.position,spawnObject.transform.position) > 0.001f)
			{
				//print("While");
				child.transform.position = Vector3.Lerp(child.transform.position,spawnObject.transform.position,GiantFunctioning.instance.speed);

				if (Vector3.Distance(child.transform.position,spawnObject.transform.position) < 0.08f)
				{
					print("Here");
					CrowdController.instance.crowdList.Remove(child);
					spawnObject.SetActive(true);
					child.SetActive(false);
					break;
				}
				yield return null;
			}	
		}
	}
}
