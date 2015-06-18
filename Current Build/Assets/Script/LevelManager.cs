using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	private static LevelManager _instance = null;
	public static LevelManager instance
	{
		get { return _instance; }
	}

	private Attractor[] _attractors;
	public Attractor[] attractors
	{
		get { return _attractors; }
	}

	//	Create a container for resources
	private int[] _resourceQuantities;

	// Use this for initialization
	void Start ()
	{
		if (_instance == null)
		{
			_instance = this;
		}
		else
		{
			Destroy(this);
			return;
		}

		//	Search for all attractors
		_attractors = (Attractor[])FindObjectsOfType<Attractor>();

		//	Create resource container
		_resourceQuantities = new int[System.Enum.GetValues(typeof(Resource.Type)).Length];
	}
	
	// Update is called once per frame
	void Update ()
	{
		//	Add pausing here
	}

	public void addResource (Resource resource)
	{
		_resourceQuantities[(int)resource.type] += resource.quantity;
		Debug.Log("Added " + resource.quantity + " " + resource.type.ToString());
	}
}
