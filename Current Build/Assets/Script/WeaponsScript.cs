using UnityEngine;
using System.Collections;

public class WeaponsScript : MonoBehaviour 
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
			print ("Weapons hit");
			ParentStats.health -= 1;
		}
	}
}
