using UnityEngine;
using System.Collections;

public class AsteroidPrefabs : MonoBehaviour
{
	private static AsteroidPrefabs _instance;
	public static AsteroidPrefabs instance
	{
		get { return _instance; }
	}

	void Awake()
	{
		_instance = this;
	}

	[SerializeField] private Transform _asteroid;

	public Transform getPrefab()
	{
		return _asteroid;
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
