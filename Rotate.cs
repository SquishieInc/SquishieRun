﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float rotateSpeed = 10;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3 (0, 0, rotateSpeed * Time.deltaTime));
	}
}
