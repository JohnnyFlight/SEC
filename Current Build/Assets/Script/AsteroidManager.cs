using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour
{
	public const float kSpawnTime = 5.0f;
	public const uint kSpawnLimit = 10;
	public const float kSpawnDistance = 100.0f;
	public const float kSpawnAngleVariance = 15.0f;

	private float _spawnCounter = 0.0f;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		_spawnCounter += Time.deltaTime;

		if (_spawnCounter >= kSpawnTime)
		{
			_spawnCounter -= kSpawnTime;

			//	Count asteroids
			Asteroid[] asteroids = (Asteroid[])FindObjectsOfType<Asteroid>();

			uint largeCount = 0;
			foreach (Asteroid asteroid in asteroids)
			{
				if (asteroid.size == Asteroid.Size.Large)
				{
					largeCount++;
				}
			}

			if (largeCount < kSpawnLimit)
			{
				SpawnAsteroid();
			}
		}
	}

	private void SpawnAsteroid()
	{
		Transform go = AsteroidPrefabs.instance.getPrefab();
		//	Select a random angle around player
		Vector3 offset = Random.insideUnitCircle;
		offset.Normalize();
		offset *= kSpawnDistance;

		GameObject ship = (GameObject)GameObject.FindGameObjectWithTag("Player");

		float angle = Mathf.Atan2(-offset.y, -offset.x) * Mathf.Rad2Deg + Random.Range(-kSpawnAngleVariance, kSpawnAngleVariance);
		print (angle);

		Instantiate(go, ship.transform.position + offset, Quaternion.AngleAxis(angle, -Vector3.forward));
	}
}
