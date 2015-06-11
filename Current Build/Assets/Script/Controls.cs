using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
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
	public float Speed;
	public float MaxSpeed;
	public float FireRate;

	// variables for storeing/manipulating
	float MovementSpeed = 0f;
	float MovementLimit = 0f;
	float AttackSpeed = 0f;

	Vector3 Accelaration;
	public Vector3 ShipVelocity;
	Vector3 TempVelocity;

	bool Moveing = false;

	// Use this for initialization
	void Start () 
	{
		MovementLimit = MaxSpeed;
		MovementSpeed = Speed;
		AttackSpeed = FireRate;
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

// Controls ////////////////////////////////////////////
		if (Input.GetKey (KeyCode.Mouse1) == true) 
		{
			ObjectPos.y += Mathf.Sin(Angle*Mathf.Deg2Rad)*Velocity;
			ObjectPos.x += Mathf.Cos(Angle*Mathf.Deg2Rad)*Velocity;
			//Vector3 NormalRotation = this.gameObject.transform.eulerAngles;
			//NormalRotation.Normalize();
			//ObjectPos += NormalRotation*Velocity*Time.deltaTime;
			this.gameObject.transform.position = ObjectPos;
		}
		if (Input.GetKey (KeyCode.A))
		{
			Accelaration = this.gameObject.transform.right * (Time.deltaTime + MovementSpeed);
			Moveing = true;
		}
		else
		{
			Moveing = false;
		}
/////////////////////////////////////////////////////////

		if (Moveing == true)
		{
			if (ShipVelocity.x < 1 && ShipVelocity.x > -1 && ShipVelocity.y < 1 && ShipVelocity.y > -1)
			{
				ShipVelocity += Accelaration;
			}
			else
			{
				ShipVelocity -= Accelaration;
			}
		}

		if (Moveing == false)
		{
			if (ShipVelocity.x > 1 && ShipVelocity.x < -1 && ShipVelocity.y > 1 && ShipVelocity.y < -1)
			{
				ShipVelocity -= Accelaration;
			}
		}

		TempVelocity = gameObject.transform.position += ShipVelocity;
		gameObject.transform.position = TempVelocity;


// Bounding Box ////////////////////////////////////////
		if (ObjectPos.x >= 35) 
		{
			ObjectPos.x = -30;
			ObjectPos.y = ObjectPos.y * -1;
			gameObject.transform.position = ObjectPos;
		}
		else if (ObjectPos.x <= -35)
		{
			ObjectPos.x = 30;
			ObjectPos.y = ObjectPos.y * -1;
			gameObject.transform.position = ObjectPos;
		}

		if (ObjectPos.y >= 25) 
		{
			ObjectPos.y = -20;
			ObjectPos.x = ObjectPos.x * -1;
			gameObject.transform.position = ObjectPos;
		}
		else if (ObjectPos.y <= -25)
		{
			ObjectPos.y = 20;
			ObjectPos.x = ObjectPos.x * -1;
			gameObject.transform.position = ObjectPos;
		}
////////////////////////////////////////////////////////
	}

	void Get_Angle()
	{
		HeightDif = Input.mousePosition.y - ObjectY;
		WidthDif = Input.mousePosition.x - ObjectX;
		Angle = Mathf.Atan2(HeightDif, WidthDif);
		Angle *= 180 / Mathf.PI;
	}
}
