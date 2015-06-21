using UnityEngine;
using System.Collections;

public class ThrusterScript : MonoBehaviour 
{
	Controls ParentControls;
	public float Speed;
	float MovementSpeed = 0f;
	// Use this for initialization
	void Start () 
	{
		MovementSpeed = Speed;
		ParentControls = transform.parent.GetComponent<Controls>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.A))
		{
			ParentControls.Accelaration = this.gameObject.transform.right * (Time.deltaTime + MovementSpeed);
			ParentControls.Moveing = true;
		}
		else
		{
			ParentControls.Moveing = false;
		}

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Bullet") 
		{
			
		} 
		else
		{
			print ("thruster hit");
		}
	}
}
