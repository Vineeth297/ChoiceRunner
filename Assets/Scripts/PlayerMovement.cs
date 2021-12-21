using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]private float xForce;
	[SerializeField]private float xSpeed;
	[SerializeField]private float forceAmount;
	private Vector3 forward = Vector3.forward;
	
	private float swipeSpeed = 15f;
	void Update()
	{
		transform.Translate((forward *forceAmount  + new Vector3(xForce * xSpeed, 0, 0)) * Time.deltaTime);

		if (transform.position.x < -1.7f)
		{
			transform.position = new Vector3(-1.7f,transform.position.y,transform.position.z);
		}

		if (transform.position.x > 1.7f)
		{
			transform.position = new Vector3(1.7f,transform.position.y,transform.position.z);
		}
			
	#if UNITY_EDITOR
			xForce = Input.GetMouseButton(0) ? Input.GetAxis("Mouse X") * xSpeed : 0;
	#elif UNITY_ANDROID
        if(Input.touchCount> 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		  {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			xForce = touchDeltaPosition.x*swipeSpeed*Mathf.Deg2Rad;
          }
	#endif
	}
	
}
