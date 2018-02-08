﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropulsionObject : MonoBehaviour {

	Rigidbody rb;

	[SerializeField]
	public float forceSpeed;


	[SerializeField]
	public int id;

	[SerializeField]
	public int level;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();


	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (transform.forward * forceSpeed *-1f,ForceMode.Force);
	}
}
