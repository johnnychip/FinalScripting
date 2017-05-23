using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Crystal : MonoBehaviour {

	public event Action OnHit;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "ship") 
		{
			GameManager.Instance.NotifyHit ();
			OnHit ();
			Destroy (gameObject);
		}
	}

}
