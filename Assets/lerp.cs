using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerp : MonoBehaviour
{
    // Start is called before the first frame update


	public GameObject g1;
	public GameObject g2;

	public float speed = 1f;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		transform.position = Vector3.Lerp(g1.transform.position, g2.transform.position, speed);
	}
}
