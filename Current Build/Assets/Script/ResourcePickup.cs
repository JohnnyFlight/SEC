using UnityEngine;
using System.Collections;

public class ResourcePickup : Resource
{
	// Use this for initialization
	void Start ()
	{
		//	Check the object has a RigidBody and a Collider
		if (this.GetComponent<Rigidbody>() == null)
			throw new UnityException("Object needs RigidBody Component");
		if (this.GetComponent<Collider>() == null)
			throw new UnityException("Object needs Collider Component");
	}
	
	// Update is called once per frame
	void Update ()
	{
		//	Query LevelManager for pickups
		foreach (Attractor attractor in LevelManager.instance.attractors)
		{
			Vector3 distance = attractor.transform.position - this.transform.position;
			if (distance.sqrMagnitude < attractor.range * attractor.range)
			{
				this.GetComponent<Rigidbody>().AddForce(distance, ForceMode.Impulse);
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			LevelManager.instance.addResource(this);
			Destroy(this.gameObject);
		}
	}
}
