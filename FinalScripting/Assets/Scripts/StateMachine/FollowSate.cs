using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSate : IEnemyState {

	private StatePaternEnemy enemy;

	public FollowSate(StatePaternEnemy statePaternEnemy)
	{
		enemy = statePaternEnemy;
	}


	public void UpdateState ()
	{
		UpdatePosition ();
	}

	public void ToFollowState ()
	{
		Debug.Log("You are here");
	}

	public void ToPatrolState ()
	{
		enemy.currentState = enemy.patrolState;
	
	}

	public void UpdatePosition()
	{

		if ((enemy.goalPosition - enemy.transform.position).magnitude > 1f)
		{
			if (enemy.rb.velocity.magnitude < enemy.maxSpeed)
				enemy.rb.AddRelativeForce (Vector3.forward * enemy.acceleration);

		} else {
			enemy.rb.velocity = Vector3.zero;
			ToPatrolState ();
		}

		if ((enemy.goalPosition - enemy.transform.position).magnitude > 5f)
			ToPatrolState ();



	}

}
