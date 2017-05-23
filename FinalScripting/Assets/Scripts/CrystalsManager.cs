using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsManager : MonoBehaviour {

	[SerializeField]
	private GameObject prefabCristal;

	[SerializeField]
	private int crystalNum;

	[SerializeField]
	private GameObject textWin;

	// Use this for initialization
	void Start () 
	{	
		CreateCrystal ();

	}

	public void CreateCrystal ()
	{
		if (crystalNum > 0) {
			Vector3 tempPosition = new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.height), 10f);
			GameObject tempObj = Instantiate (prefabCristal, Camera.main.ScreenToWorldPoint (tempPosition), Quaternion.identity);
			tempObj.GetComponent<Crystal> ().OnHit += CreateCrystal;
			crystalNum--;
		} else {
			textWin.SetActive (true);
		}

	}


}
