using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	public float HeightDif = 0f;
	public float WidthDif = 0f;
	public float Velocity = 0.3f;
	public float Angle;
	public Vector3 ObjectRot;
	public Vector3 ObjectPos;
	public float ObjectY;
	public float ObjectX;
	public float CameraX;
	public float CameraY;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 ObjectScreenPos = Camera.main.WorldToScreenPoint (this.gameObject.transform.position);
		ObjectPos = this.gameObject.transform.position;
		ObjectX = ObjectScreenPos.x;
		ObjectY = ObjectScreenPos.y;
		CameraX = Camera.main.transform.position.x;
		CameraY = Camera.main.transform.position.y;
		CameraX = ObjectX; 
		CameraY = ObjectY; 
		ObjectRot = this.gameObject.transform.eulerAngles;
		Get_Angle ();
		ObjectRot.z = Angle;
		this.gameObject.transform.eulerAngles = ObjectRot;

		if (Input.GetKey (KeyCode.Mouse1) == true) 
		{
			ObjectPos.y += Mathf.Sin(Angle*Mathf.Deg2Rad)*Velocity;
			ObjectPos.x += Mathf.Cos(Angle*Mathf.Deg2Rad)*Velocity;
			//Vector3 NormalRotation = this.gameObject.transform.eulerAngles;
			//NormalRotation.Normalize();
			//ObjectPos += NormalRotation*Velocity*Time.deltaTime;
			this.gameObject.transform.position = ObjectPos;
		}
	}

	void Get_Angle()
	{
		HeightDif = Input.mousePosition.y - ObjectY;
		WidthDif = Input.mousePosition.x - ObjectX;
		Angle = Mathf.Atan2(HeightDif, WidthDif);
		Angle *= 180 / Mathf.PI;
	}
}
