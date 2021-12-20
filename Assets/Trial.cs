using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Trial : MonoBehaviour
{
    // Start is called before the first frame update

	public GameObject child;
	public GameObject obj;
    void Start()
    {
        obj.transform.DOMove(child.transform.position,2f).SetEase(Ease.OutExpo).OnComplete(() =>
		{
			obj.SetActive(false);
			child.SetActive(true);
		});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
