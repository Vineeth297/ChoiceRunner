using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMovement : MonoBehaviour
{

	[Header("Movement")]
	[SerializeField]private float xForce;
	[SerializeField]private float xSpeed;
	[SerializeField]private float forceAmount;
	private Vector3 forward = Vector3.forward;

	private float swipeSpeed = 15f;
	[Header("Follow Properties")]
	public float speed;
	public Transform player;
	public float minimumDistance;
	public float damping;
	private float desiredRot;
	public float rotSpeed = 250;

	void Start()
	{
		desiredRot = transform.eulerAngles.y;
				
	}
	
	void Update()
    {
		if (PlayerMovement.instance.isOnGround)
		{
			// if (Vector3.Distance(transform.position,player.position) > minimumDistance)
			// {
			// 	transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
			// 	// transform.rotation = player.transform.rotation;
			// 	// if (player.transform.position.x > Screen.width/2)
			// 	// {
			// 	// 	desiredRot -= rotSpeed * Time.deltaTime;
			// 	// }
			// 	// else
			// 	// {
			// 	// 	desiredRot += rotSpeed * Time.deltaTime;
			// 	// }
			// 	// var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot,transform.eulerAngles.z );
			// 	// transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ,Time.deltaTime * damping);
			// 	// // transform.LookAt(player.transform);
			// }
			transform.Translate((forward * forceAmount + new Vector3(xForce * xSpeed,0,0)) * Time.deltaTime);

			if (transform.position.x < -1.7f)
			{
				transform.position = new Vector3(-1.7f, transform.position.y,transform.position.z);
			}

			if (transform.position.x > 1.7f)
			{
				transform.position = new Vector3(1.7f, transform.position.y, transform.position.z);
			}	
		}
		
		// if (Vector3.Distance(transform.position,player.position) > minimumDistance)
		// {
		// 	transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		// 	// transform.rotation = player.transform.rotation;
		// 	// if (player.transform.position.x > Screen.width/2)
		// 	// {
		// 	// 	desiredRot -= rotSpeed * Time.deltaTime;
		// 	// }
		// 	// else
		// 	// {
		// 	// 	desiredRot += rotSpeed * Time.deltaTime;
		// 	// }
		// 	// var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot,transform.eulerAngles.z );
		// 	// transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ,Time.deltaTime * damping);
		// 	// // transform.LookAt(player.transform);
		// }
		
		
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
