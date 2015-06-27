using UnityEngine;
using System.Collections;

public class HullScript : MonoBehaviour 
{
	ShipStats ParentStats;
	// Use this for initialization
	void Start () 
	{
		ParentStats = transform.parent.GetComponent<ShipStats>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision col)
	{

		if (col.gameObject.tag == "Bullet") 
		{
				
		} 
		else
		{
			print ("hull hit");
			ParentStats.health -= 1;
		}
	}
}
