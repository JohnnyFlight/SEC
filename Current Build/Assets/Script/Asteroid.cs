using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
	public enum Size { Small, Medium, Large }

	public const float kDefaultSmallHealth = 20.0f;
	public const float kDefaultMediumHealth = 50.0f;
	public const float kDefaultLargeHealth = 100.0f;

	public const float kDefaultHealth = 0.0f;
	public const Size kDefaultSize = Size.Large;

	public const float kDefaultVelocity = 25.0f;

	public const float kCubeRoot2 = 1.25992104989f;
	public const float kCubeRoot3 = 1.44224957031f;

	private float[] _unforcedDamage = { 30.0f, 50.0f, 70.0f };

	//	Otherwise split 2
	public const float kThreeBreakPercentage = 30.0f;
	
	[SerializeField] protected float _health = kDefaultHealth;
	public float health
	{
		get { return _health; }
	}

	[SerializeField] protected Size _size = kDefaultSize;

	[SerializeField] private float _velocity = kDefaultVelocity;
	public float velocity
	{
		get { return _velocity; }
		set { _velocity = value; }
	}

	[SerializeField] private bool _forcedMovement = false;

	public Size size
	{
		get { return _size; }
		set { _size = value; }
	}

	// Use this for initialization
	void Start ()
	{
		rigidbody.AddForce(transform.right, ForceMode.VelocityChange);

		//	Assume 0 health at start means size has not been initiated
		if (_health <= 0.0f)
		{
			switch (_size)
			{
				case Size.Small:
					_health = kDefaultSmallHealth;
					break;
				case Size.Medium:
					_health = kDefaultMediumHealth;
					break;
				case Size.Large:
					_health = kDefaultLargeHealth;
					break;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_health <= 0.0f)
		{
			Debug.Log(this + "Destroyed");
			Destroy(gameObject);

			GameObject go;
			switch (_size)
			{
				case Size.Small:
					//	Do nothing

					break;
				case Size.Medium:
					//	Create two smalls
					if (Random.Range(0.0f, 100.0f) < kThreeBreakPercentage)
						split(2, Asteroid.Size.Small);
					else
						split(3, Asteroid.Size.Small);
					break;
				case Size.Large:
				//	Create two mediums
				if (Random.Range(0.0f, 100.0f) < kThreeBreakPercentage)
					split(2, Asteroid.Size.Medium);
				else
					split(3, Asteroid.Size.Medium);
				break;
			}
		}
	}

	void OnMouseDown()
	{
		Debug.Log(this + "clicked.");
		_health -= 25.0f;
	}

	void OnCollisionEnter(Collision col)
	{
		print (col.gameObject.tag);
		if (col.gameObject.tag == "Bullet")
		{
			//	Get vector from collider to asteroid
			Vector3 direction = this.transform.position - col.transform.position;
			this.GetComponent<Rigidbody>().AddForce(direction.normalized, ForceMode.Impulse);

			_health -= 10.0f;
		}
		else if (col.gameObject.tag == "Asteroid")
		{
			if (_forcedMovement == true)
			{
				//	Do damage to both asteroids
			}
		}
	}

	private void split(uint number, Asteroid.Size s)
	{
		//	Get rotation
		Quaternion q = Quaternion.AngleAxis((360.0f / (float)number) / 2.0f, Vector3.forward);
		Quaternion rotation = this.transform.rotation;
		GameObject go;
		float scaleFactor = Mathf.Pow(number, 1.0f / 3.0f);

		//	Rotate 360 / n / 2 degrees around z-axis
		if (number % 2 == 0)
		{
			rotation *= q;
		}

		for (uint i = 0; i < number; i++)
		{
			//	Create instance
			go = ((Transform)Instantiate(AsteroidPrefabs.instance.getPrefab(), this.transform.position, rotation)).gameObject;
			go.transform.localScale = this.transform.localScale / scaleFactor;

			Vector3 position = go.transform.position;
			position += go.transform.right * 2.0f;
			position.z = 0.0f;
			go.transform.position = position;

			go.GetComponent<Asteroid>().size = s;

			rotation *= q;
			rotation *= q;
		}
	}

}
