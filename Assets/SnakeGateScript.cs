using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGateScript : MonoBehaviour
{
	public bool isUsed;
	
	void OnTriggerEnter(Collider other)
	{
		if (isUsed) return;

		if (other.CompareTag("Player"))
		{
			if (GiantFunctioning.instance.isGiant)
			{
				for (int i = GiantFunctioning.instance.usedGiantManChildren.Count; i > 0; i--)
				{
					GiantFunctioning.instance.speed = 0.5f;
					GameObject obj = GiantFunctioning.instance.usedGiantManChildren[i - 1];
					//obj.GetComponent<CrowdFollow>().enabled = false;
			
					StartCoroutine(MoveToSnake(obj));
				}
			}
			
			if (BirdFunctioning.instance.isBird)
			{
				for (int i = BirdFunctioning.instance.usedBirdChildren.Count; i > 0; i--)
				{
					BirdFunctioning.instance.speed = 0.5f;
					GameObject obj = BirdFunctioning.instance.usedBirdChildren[i - 1];
					//obj.GetComponent<CrowdFollow>().enabled = false;
			
					StartCoroutine(MoveToSnake(obj));
				}
			}
			
			print("player came here");
			SnakeFunctioning.instance.SnakeTransformation();
			//CreatureFunctioning.only.IDKTHISISTHEACCESSPOINTOTHISCLASS();
			isUsed = true;	
		}
	}

	IEnumerator MoveToSnake(GameObject child)
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
					if (GiantFunctioning.instance.isGiant)
					{
						GiantFunctioning.instance.usedGiantManChildren.Remove(child);
						spawnObject.SetActive(true);
						child.SetActive(false);
						break;
					}

					if (BirdFunctioning.instance.isBird)
					{
						BirdFunctioning.instance.usedBirdChildren.Remove(child);
						spawnObject.SetActive(true);
						child.SetActive(false);
						break;
					}

					if (SnakeFunctioning.instance.isSnake)
					{
						CrowdController.instance.crowdList.Remove(child);
						spawnObject.SetActive(true);
						child.SetActive(false);
						break;
					}
				}
				yield return null;
			}	
		}
	}
}
