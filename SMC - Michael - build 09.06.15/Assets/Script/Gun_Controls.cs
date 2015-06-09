using UnityEngine;
using System.Collections;

public class Gun_Controls : MonoBehaviour 
{
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
	public float FireRate;
	public float delayTime = 0f;
	//public float BulletSpeed;

	public GameObject TempShot;

	// variables for storing/manipulateing
	float AttackSpeed;
	//float ShotSpeed;

	Vector3 ShotVelocity;
	Vector3 Acceleration;

	bool shooting = false;

	// Use this for initialization
	void Start () 
	{
		AttackSpeed = FireRate;
		//ShotSpeed = BulletSpeed;
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

		delayTime += Time.deltaTime;

		if (Input.GetKey (KeyCode.S)) 
		{
			shooting = true;
		} else 
		{
			shooting = false;
		}

		if(shooting == true)
		{
			if(delayTime >= FireRate)
			{
				Instantiate(TempShot, ObjectPos, Quaternion.identity);
				TempShot.gameObject.transform.eulerAngles = ObjectRot;
				delayTime = 0;
			}
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
