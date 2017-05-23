using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState {

	private StatePaternEnemy enemy;

	public PatrolState(StatePaternEnemy statePaternEnemy)
	{
		enemy = statePaternEnemy;
	}



	public void UpdateState ()
	{
		UpdatePosition ();
	}

	public void ToFollowState ()
	{
		enemy.currentState = enemy.followState;
		Debug.Log("You are in Follow State");
	}

	public void ToPatrolState ()
	{
		Debug.Log("You are here");
	}

	public void UpdatePosition()
	{

		if ((enemy.goalPosition - enemy.transform.position).magnitude > 2f)
		{
			if (enemy.rb.velocity.magnitude < enemy.maxSpeed)
				enemy.rb.AddRelativeForce (Vector3.forward * enemy.acceleration);

		} else {
			enemy.rb.velocity = Vector3.zero;
			enemy.ChangePath ();
			enemy.StartLerp ();
		}



	}

	public void CheckPlayerNear()
	{
		if ((enemy.targer.position - enemy.transform.position).magnitude < 5) {
			enemy.StartLerpTarget ();
			ToFollowState ();
		}
	}


}
