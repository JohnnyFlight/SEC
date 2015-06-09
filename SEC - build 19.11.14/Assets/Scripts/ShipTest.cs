using UnityEngine;
using System.Collections;

public class ShipTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			transform.rigidbody.AddForce(transform.right * 100.0f);
		}
	}
}
