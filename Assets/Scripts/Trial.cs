using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Trial : MonoBehaviour
{
    // Start is called before the first frame update

	public List<GameObject> child;
	public List<GameObject> obj;
    void Start()
    {
		print(child.Count);
		for (int i = 0; i < child.Count ; i++)
		{
			var bacha = child[i];
			var kucha = obj[i];
			obj[i].transform.DOMove(child[i].transform.position,1f).SetEase(Ease.OutExpo).OnComplete(() =>
			{
				bacha.SetActive(true);
				kucha.SetActive(false);
			});	
		}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
