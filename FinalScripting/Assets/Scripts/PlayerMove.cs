using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	[SerializeField]
	private float acceleration;

	[SerializeField]
	private float maxSpeed;

	private bool isMoving;
	private Vector3 goalPosition;
	private Vector3 startPosition;
	private float elapsedTime;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	private void Update()
	{

		if (Input.GetMouseButtonDown(0))
			StartLerp();
		if(isMoving)
		UpdatePosition ();
	}

	private void StartLerp()
	{
		rb.velocity = Vector3.zero;
		startPosition = transform.position;
		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouse.z = transform.position.z;
		goalPosition = mouse;
		transform.rotation = Quaternion.LookRotation((goalPosition-startPosition).normalized);
		Debug.Log (goalPosition);
		isMoving = true;
	}

	private void UpdatePosition()
	{
		
		if ((goalPosition - transform.position).magnitude > 1f)
		{
			if (rb.velocity.magnitude < maxSpeed)
				rb.AddRelativeForce (Vector3.forward * acceleration);
		
		} else {
			rb.velocity = Vector3.zero;
			isMoving = false;
		}


			
	}


}
