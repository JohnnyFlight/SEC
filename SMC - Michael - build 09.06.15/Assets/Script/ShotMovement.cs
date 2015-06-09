using UnityEngine;
using System.Collections;

public class ShotMovement : MonoBehaviour {

	// user dictated variables
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
	public float BulletSpeed;

	// variables for storing/manipulateing
	float ShotSpeed;

	Vector3 Acceleration;
	Vector3 ShotVelocity;


	// Use this for initialization
	void Start () 
	{
		ShotSpeed = BulletSpeed;
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
	}
	
	// Update is called once per frame
	void Update () 
	{
		Acceleration = this.gameObject.transform.right * (Time.deltaTime + ShotSpeed);
		ShotVelocity += Acceleration;
		Vector3 temp = this.gameObject.transform.position += ShotVelocity;
		this.gameObject.transform.position = temp;
	}

	void Get_Angle()
	{
		HeightDif = Input.mousePosition.y - ObjectY;
		WidthDif = Input.mousePosition.x - ObjectX;
		Angle = Mathf.Atan2(HeightDif, WidthDif);
		Angle *= 180 / Mathf.PI;
	}
}
