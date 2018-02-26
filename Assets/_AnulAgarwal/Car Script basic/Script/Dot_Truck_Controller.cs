using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Dot_Truck : System.Object
{
	public WheelCollider wheel;
	public GameObject wheelMesh;

	public bool motor;
	public bool steering;
	public bool reverseTurn; 
}

public class Dot_Truck_Controller : MonoBehaviour {

	public float maxMotorTorque;
	public float maxSteeringAngle;
	public List<Dot_Truck> truck_Infos;
	[SerializeField]
	public List<Wheel> wheelInfo;


	public void VisualizeWheel(Wheel wheelPair)
	{
		Quaternion rot;
		Vector3 pos;
		wheelPair.wheel.GetWorldPose ( out pos, out rot);
		wheelPair.wheelMesh.transform.position = pos;
		wheelPair.wheelMesh.transform.rotation = rot;

	}

	public void Update()
	{
		float motor = maxMotorTorque ;
		float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
		float brakeTorque = Mathf.Abs(Input.GetAxis("Jump"));
		if (brakeTorque > 0.001) {
			brakeTorque = maxMotorTorque;
			motor = 0;
		} else {
			brakeTorque = 0;
		}

		foreach (Wheel truck_Info in wheelInfo)
		{
			if (truck_Info == null  ) {
				wheelInfo.Remove (truck_Info);
				break;
			}
			if (truck_Info.steering == true) {
				truck_Info.wheel.steerAngle = ((truck_Info.reverseTurn)?-1:1)*steering;
			}

			if (truck_Info.motor == true)
			{
				truck_Info.wheel.motorTorque = motor;
	
			}

			truck_Info.wheel.brakeTorque = brakeTorque;
	

			VisualizeWheel(truck_Info);
		}

	}


}