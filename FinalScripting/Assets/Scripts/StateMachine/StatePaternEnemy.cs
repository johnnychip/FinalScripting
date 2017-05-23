using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePaternEnemy : MonoBehaviour {

	[SerializeField]
	public float acceleration;

	[SerializeField]
	public float maxSpeed;

	[SerializeField]
	public Transform targer;

	private bool isMoving;
	public Vector3 goalPosition;
	public Vector3 startPosition;
	private float elapsedTime;
	public Rigidbody rb;
	public int currentPosition;
	/// <summary>
	/// ///////////////////////////////////////
	/// </summary>

	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public FollowSate followState;
	[HideInInspector] public Transform target;

	public int actualPoint;

	public float timePath;

	public Transform[] path = new Transform[2];

	void Awake ()
	{

		patrolState = new PatrolState (this);
		followState = new FollowSate (this);

	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		currentState = patrolState;
		goalPosition = path [currentPosition].position;
	}
	
	// Update is called once per frame
	void Update () {
		currentState.UpdateState ();
	}

	public void OnTriggerEnter(Collider other)
	{
		
	}
		
	public void StartLerp()
	{
		rb.velocity = Vector3.zero;
		startPosition = transform.position;
		goalPosition = path[currentPosition].position;
		transform.rotation = Quaternion.LookRotation((goalPosition-startPosition).normalized);
		Debug.Log (goalPosition);
	
	}

	public void StartLerpTarget()
	{
		rb.velocity = Vector3.zero;
		startPosition = transform.position;
		goalPosition = target.position;
		transform.rotation = Quaternion.LookRotation((goalPosition-startPosition).normalized);
		Debug.Log (goalPosition);

	}


	public void ChangePath ()
	{
		currentPosition++;
		currentPosition = currentPosition % path.Length;
	}



}
