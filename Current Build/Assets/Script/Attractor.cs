using UnityEngine;
using System.Collections;

public class Attractor : MonoBehaviour
{
	private const float kDefaultRange = 5.0f;

	[SerializeField] private float _range = kDefaultRange;
	public float range
	{
		get { return _range; }
	}
}
