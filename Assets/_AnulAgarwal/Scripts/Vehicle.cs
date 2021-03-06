﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

	[SerializeField]
	public VehicleBody vb;

	[SerializeField]
	public PropulsionObject po;

	[SerializeField]
	public List<Wheel> wheels;

	[SerializeField]
	public List<GameObject> spawnerList;

	[SerializeField]
	public GameManager gm;

	[SerializeField]
	public List<GameObject> attachmentPoints;


	[SerializeField]
	public List<PropulsionObject> propObj;


	public Chasis chasis;

	public int numberOfEngine;

	public enum Character {Hopper, Booster, Heavy

	};

	public enum States
	{
		Stopped,
		Moving,
		Drifting,
		Oily}

	;

	// Use this for initialization
	void Start () {
		
	}
		
	public void enableCarEditing(){

		foreach (GameObject go in attachmentPoints) {

			go.SetActive (true);
		}
	}

	public void disableCarEditing(){

		foreach (GameObject go in attachmentPoints) {

			go.SetActive (false);
		}
	}

	public void enableCarPower(){
		//enable rigidbody & gravity from all attached items
		//enable car movement
		//enable propulsion movement
		//Disable object rotation
		//Make camera follow car from a distance

		//Enable rigidbody
		GetComponentInChildren<Rigidbody>().useGravity = true;
		transform.rotation = Quaternion.Euler (0, 90, 0);
	
		//Disable object rotation
		GetComponent<MouseRotate> ().enabled = false;
		disableCarEditing ();

		vb.callController ();
//		gm.switchCam ();
	}
	public void changeCarSpeedForThisMuchTime(float speedDecreasePercentage, float duration){



	}
	public void disableCarPower(){

		//disable rigidbody & gravity from all applicable items
		//disable car movement 
		//disable propulsion movement
		//Enable object rotation


		//playerVehicle.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		GetComponent<Rigidbody> ().useGravity = false;
		GetComponent<Engine> ().enabled = false;
		if(GetComponentInChildren<PropulsionObject>()!= null){
			GetComponentInChildren<PropulsionObject> ().enabled = false;

			GetComponentInChildren<PropulsionObject> ().GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			GetComponentInChildren<PropulsionObject> ().GetComponent<Rigidbody> ().useGravity = false;

		}

		GetComponent<MouseRotate> ().enabled = true;
		enableCarEditing ();

		//gm.switchCam ();
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void doBoosterPizzaUltimate(){
		//increase speed
		//2x current speed for 3s
		print("Boooosting");

		vb.changeCarSpeedForThisMuchTime (-50f, 5f);
	}


	public void doHopperPizzaUltimate(){
		//5cm vertical jumjp
		//Airborne for 3s
		print("Hopppinggg");
		vb.jumpCar ();
	}

	public void doHeavyPizzaUltimate(){
		// Invulnerable for 3 sec
		//Knocks over objects
		
		print("Invulnerableeee");

	}

	public void doOnPepperoniEnter(Collider col){
		gm.increasePowerBar(col.gameObject.GetComponent<Pepperoni>().ultimatePowerValue);
		Destroy(col.gameObject);


	}
	void increasePowerBar(int value){



	}
}
